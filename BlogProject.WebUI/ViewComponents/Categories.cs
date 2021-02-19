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
        private readonly ICategoryService _categoryService;
        public Categories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _categoryService.GetAllAsync().Result;
            if (result.Success)
            {
                result.Data.Adapt<List<CategoryListDto>>();
            }
            return View();
        }
    }
}
