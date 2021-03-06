﻿using BlogProject.Core.DataAccess.EntityFramework;
using BlogProject.DataAccess.Abstract;
using BlogProject.DataAccess.Concrete.Context;
using BlogProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccess.Concrete.Repositories.EfRepositories
{
    public class EfArticleRepository : EfGenericRepository<Article, BlogContext>, IArticleDal
    {
        public async Task<Article> GetArticleWithCommentsByIdAsync(int id)
        {
            using var context = new BlogContext();
            return await context.Articles.Include(x => x.Comments.OrderByDescending(x=>x.Id)).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
