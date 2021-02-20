using BlogProject.Business.Abstract;
using BlogProject.DTO.Concrete.CategoryDTOs;
using BlogProject.Entities.Concrete;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "category";
            var result = await _categoryService.GetAllAsync();
            return View(result.Data.Adapt<List<CategoryListDto>>());
        }

        public IActionResult Add()
        {
            TempData["Active"] = "category";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(category.Adapt<Category>());
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["Active"] = "category";
            var category = await _categoryService.GetByIdAsync(id);
            if (category.Success)
            {
                return View(category.Data.Adapt<CategoryEditDto>());
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditDto category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(category.Adapt<Category>());
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(new Category { Id = id });
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
