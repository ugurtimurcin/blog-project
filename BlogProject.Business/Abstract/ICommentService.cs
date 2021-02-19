using BlogProject.Core.Utilities.Results.Abstract;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        Task<IDataResult<List<Comment>>> GetCommentsWithArticleAsync();
        Task<IDataResult<Comment>> GetCommentByIdWithArticleAsync(int id);
    }
}
