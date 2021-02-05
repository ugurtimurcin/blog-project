using BlogProject.Business.Abstract;
using BlogProject.DTO.Concrete.ArticleDTOs;
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
        private readonly IGenericService<Article> _genericService;
        public HomeController(IGenericService<Article> genericService)
        {
            _genericService = genericService;
        }
        public async Task<IActionResult> Index()
        {
            var articles = await _genericService.GetAllAsync(x => x.Id);
            return View(articles.Adapt<List<ArticleListDto>>());
        }

        public async Task<IActionResult> Detail(int id)
        {
            var article = await _genericService.GetByIdAsync(id);
            return View(article.Adapt<ArticleListDto>());
        }
    }
}
