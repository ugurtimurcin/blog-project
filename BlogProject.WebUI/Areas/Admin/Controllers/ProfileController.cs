using BlogProject.DTO.Concrete.AppUserDTOs;
using BlogProject.Entities.Concrete;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(user.Adapt<AppUserListDto>());
        }

        public async Task<IActionResult> Edit()
        {
            TempData["Active"] = "profile";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(user.Adapt<AppUserEditDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AppUserEditDto appUser, IFormFile pic)
        {
            var user = await _userManager.FindByIdAsync(appUser.Id);
            if (pic != null)
            {
                var picName = user.UserName + "_" + Guid.NewGuid() + Path.GetExtension(pic.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/profile-picture/" + picName);
                using var stream = new FileStream(path, FileMode.Create);
                await pic.CopyToAsync(stream);

                user.ProfilPicture = picName;
            }

            user.FirstName = appUser.FirstName;
            user.LastName = appUser.LastName;
            user.Email = appUser.Email;
            user.ProfilPicture = user.ProfilPicture;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = "Your profile has updated!";
                return RedirectToAction("Index", "Profile", new { area = "Admin" });
            }

            return View(appUser);
        }

        public IActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Password(AppUserPasswordChangeDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Your password has changed!";
                        return RedirectToAction("Index", "Profile", new { area = "Admin" });
                    }
                }
            }
            return View();
        }
    }
}
