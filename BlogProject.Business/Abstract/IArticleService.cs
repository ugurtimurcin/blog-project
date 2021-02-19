using BlogProject.Core.Utilities.Results.Abstract;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        Task<IDataResult<Article>> GetArticleWithCommentsByIdAsync(int id);
    }
}
