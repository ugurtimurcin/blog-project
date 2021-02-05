using BlogProject.Business.Abstract;
using BlogProject.DTO.Concrete.CategoryDTOs;
using BlogProject.Entities.Concrete;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WebUI.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly IGenericService<Category> _genericService;
        public Categories(IGenericService<Category> genericService)
        {
            _genericService = genericService;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _genericService.GetAllAsync(x => x.Id).Result;
            return View(categories.Adapt<List<CategoryListDto>>());
        }
    }
}
