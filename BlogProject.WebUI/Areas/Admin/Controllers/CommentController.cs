using BlogProject.Business.Abstract;
using BlogProject.DTO.Concrete.CommentDTOs;
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
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IGenericService<Comment> _genericService;
        public CommentController(ICommentService commentService, IGenericService<Comment> genericService)
        {
            _commentService = commentService;
            _genericService = genericService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "comment";
            var comments = await _commentService.GetCommentsWithArticleAsync();
            return View(comments.Adapt<List<CommentListDto>>());
        }

        public async Task<IActionResult> Edit(int id)
        {
            TempData["Active"] = "comment";
            var comment = await _commentService.GetCommentByIdWithArticleAsync(id);
            return View(comment.Adapt<CommentEditDto>());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CommentEditDto dto)
        {
            var comment =await _commentService.GetByIdAsync(dto.Id);
            comment.IsActive = true;
            await _commentService.UpdateAsync(comment);
            return RedirectToAction("Index", "Comment", new { area = "Admin" });
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteAsync(new Comment { Id = id });
            return Json(null);
        }
    }
}
