﻿using BlogProject.Business.Abstract;
using BlogProject.Business.Concrete;
using BlogProject.Business.ValidationRules.FluentValidation;
using BlogProject.Core.DataAccess;
using BlogProject.Core.DataAccess.EntityFramework;
using BlogProject.Core.Entities;
using BlogProject.DataAccess.Abstract;
using BlogProject.DataAccess.Concrete.Context;
using BlogProject.DataAccess.Concrete.Repositories.EfRepositories;
using BlogProject.DTO.Concrete.ArticleDTOs;
using BlogProject.DTO.Concrete.CategoryDTOs;
using BlogProject.DTO.Concrete.CommentDTOs;
using BlogProject.Entities.Concrete;
using FluentValidation;
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

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddTransient<IValidator<ArticleAddDto>, ArticleAddValidator>();
            services.AddTransient<IValidator<ArticleEditDto>, ArticleEditValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryEditDto>, CategoryEditValidator>();
            services.AddTransient<IValidator<CommentAddDto>, CommentAddValidator>();


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
