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
        private readonly IGenericService<Category> _genericService;
        public CategoryController(IGenericService<Category> genericService)
        {
            _genericService = genericService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "category";
            var categories = await _genericService.GetAllAsync();
            return View(categories.Adapt<List<CategoryListDto>>());
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
                await _genericService.AddAsync(category.Adapt<Category>());
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["Active"] = "category";
            var category = await _genericService.GetByIdAsync(id);
            if (category != null)
            {
                return View(category.Adapt<CategoryEditDto>());
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditDto category)
        {
            if (ModelState.IsValid)
            {
                await _genericService.UpdateAsync(category.Adapt<Category>());
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _genericService.DeleteAsync( await _genericService.GetByIdAsync(id));
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}
