using BlogProject.Business.Abstract;
using BlogProject.Business.Concrete;
using BlogProject.DataAccess.Abstract;
using BlogProject.DataAccess.Concrete.Context;
using BlogProject.DataAccess.Concrete.Repositories.EfRepositories;
using BlogProject.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Dependencies.MicrosoftIoC
{
    public static class CustomDependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleRepository>();

            services.AddDbContext<BlogContext>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "Web.Security.Cookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(15);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Login/Index";
                opt.AccessDeniedPath = "/Home/Index";
            });
        }
    }
}
