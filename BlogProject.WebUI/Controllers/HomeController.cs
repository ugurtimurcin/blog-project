using BlogProject.Business.Abstract;
using BlogProject.DTO.Concrete.ArticleDTOs;
using BlogProject.DTO.Concrete.CommentDTOs;
using BlogProject.Entities.Concrete;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericService<Comment> _genericService;
        private readonly IArticleService _articleService;
        public HomeController(IGenericService<Comment> genericService, IArticleService articleService)
        {
            _genericService = genericService;
            _articleService = articleService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _articleService.GetAllAsync();
            if (result.Success)
            {
                return View(result.Data.Adapt<List<ArticleListDto>>());
            }
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.Article = await _articleService.GetArticleWithCommentsByIdAsync(id);
           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddDto model)
        {
            if (ModelState.IsValid)
            {
                await _genericService.AddAsync(model.Adapt<Comment>());
            }
            return RedirectToAction("Detail","Home",new { id = model.ArticleId });
        }
    }
}
