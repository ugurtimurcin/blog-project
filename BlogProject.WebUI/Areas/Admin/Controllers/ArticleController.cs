using BlogProject.Business.Abstract;
using BlogProject.DTO.Concrete.ArticleDTOs;
using BlogProject.DTO.Concrete.CategoryDTOs;
using BlogProject.Entities.Concrete;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IGenericService<Article> _genericService;
        private readonly IGenericService<Category> _categoryService;
        public ArticleController(IGenericService<Article> genericService, IGenericService<Category> categoryService)
        {
            _genericService = genericService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "article";
            var articles = await _genericService.GetAllAsync(x=>x.Id);
            return View(articles.Adapt<List<ArticleListDto>>());
        }

        public IActionResult Add()
        {
            TempData["Active"] = "article";
            ViewBag.Categories = new SelectList(_categoryService.GetAllAsync().Result.Adapt<List<CategoryListDto>>(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleAddDto model, IFormFile pic)
        {
            if (pic != null)
            {
                var picName = Guid.NewGuid() + Path.GetExtension(pic.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/article-cover/" + picName);
                using var stream = new FileStream(path, FileMode.Create);

                await pic.CopyToAsync(stream);

                model.ImagePath = picName;
            }
            if (ModelState.IsValid)
            {
                var article = new Article()
                {
                    Title = model.Title,
                    Content = model.Content,
                    CategoryId = model.CategoryId,
                    ImagePath = model.ImagePath,
                    Url = Guid.NewGuid().ToString()

                };
                await _genericService.AddAsync(article);
                return RedirectToAction("Index", "Article", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var article = await _genericService.GetByIdAsync(id);
            ViewBag.Categories = new SelectList(_categoryService.GetAllAsync().Result.Adapt<List<CategoryListDto>>(), "Id", "Name");
            return View(article.Adapt<ArticleEditDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleEditDto article, IFormFile pic)
        {
            var updatedArticle = await _genericService.GetByIdAsync(article.Id);
            if (pic != null)
            {
                var picName = Guid.NewGuid() + Path.GetExtension(pic.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/article-cover/" + picName);
                using var stream = new FileStream(path, FileMode.Create);
                await pic.CopyToAsync(stream);

                updatedArticle.ImagePath = picName;
            }
            if (ModelState.IsValid)
            {
                updatedArticle.Title = article.Title;
                updatedArticle.Content = article.Content;
                updatedArticle.CategoryId = article.CategoryId;

                await _genericService.UpdateAsync(updatedArticle);
                return RedirectToAction("Index", "Article", new { area = "Admin" });
            }

            return View(article);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _genericService.DeleteAsync(await _genericService.GetByIdAsync(id));
            return RedirectToAction("Index", "Article", new { area = "Admin" });
        }
    }
}
