using BlogProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                var admin = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@blogproject.com",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "firstname",
                    LastName = "lastname"
                };

                await userManager.CreateAsync(admin, "Admin.123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
