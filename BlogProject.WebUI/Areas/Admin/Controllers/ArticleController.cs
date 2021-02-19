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
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "article";
            var result = await _articleService.GetAllAsync();
            return View(result.Data.Adapt<List<ArticleListDto>>());
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
                await _articleService.AddAsync(article);
                return RedirectToAction("Index", "Article", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var article = await _articleService.GetByIdAsync(id);
            ViewBag.Categories = new SelectList(_categoryService.GetAllAsync().Result.Adapt<List<CategoryListDto>>(), "Id", "Name");
            return View(article.Adapt<ArticleEditDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ArticleEditDto article, IFormFile pic)
        {
            var updatedArticle = await _articleService.GetByIdAsync(article.Id);
            if (pic != null)
            {
                var picName = Guid.NewGuid() + Path.GetExtension(pic.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/article-cover/" + picName);
                using var stream = new FileStream(path, FileMode.Create);
                await pic.CopyToAsync(stream);

                updatedArticle.Data.ImagePath = picName;
            }
            if (ModelState.IsValid)
            {
                updatedArticle.Data.Title = article.Title;
                updatedArticle.Data.Content = article.Content;
                updatedArticle.Data.CategoryId = article.CategoryId;

                await _articleService.UpdateAsync(updatedArticle.Data);
                return RedirectToAction("Index", "Article", new { area = "Admin" });
            }

            return View(article);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _articleService.DeleteAsync(new Article { Id = id });
            return RedirectToAction("Index", "Article", new { area = "Admin" });
        }
    }
}
