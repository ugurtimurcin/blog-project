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
        private readonly ICommentService _commentService;
        private readonly IArticleService _articleService;
        public HomeController(ICommentService commentService, IArticleService articleService)
        {
            _commentService = commentService;
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
            var result = await _articleService.GetArticleWithCommentsByIdAsync(id);
            ViewBag.Article = result.Data;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddDto model)
        {
            if (ModelState.IsValid)
            {
                await _commentService.AddAsync(model.Adapt<Comment>());
            }
            return RedirectToAction("Detail","Home",new { id = model.ArticleId });
        }
    }
}
