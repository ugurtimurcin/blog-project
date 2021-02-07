using BlogProject.Core.DataAccess.EntityFramework;
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
    public class EfCommentRepository : EfGenericRepository<Comment, BlogContext>, ICommentDal
    {
        public async Task<Comment> GetCommentByIdWithArticleAsync(int id)
        {
            using var context = new BlogContext();
            return await context.Comments.Include(x => x.Article).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Comment>> GetCommentsWithArticleAsync()
        {
            using var context = new BlogContext();
            return await context.Comments.Include(x => x.Article).OrderByDescending(x => x.Id).ToListAsync();
        }
    }
}
