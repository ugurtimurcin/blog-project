using BlogProject.Core.DataAccess;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccess.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        Task<List<Comment>> GetCommentsWithArticleAsync();
        Task<Comment> GetCommentByIdWithArticleAsync(int id);
    }
}
