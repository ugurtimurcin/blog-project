using BlogProject.Business.Abstract;
using BlogProject.Core.DataAccess;
using BlogProject.Core.Utilities.Results.Abstract;
using BlogProject.Core.Utilities.Results.Concrete;
using BlogProject.DataAccess.Abstract;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public async Task<IResult> AddAsync(Article entity)
        {
            await _articleDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Article entity)
        {
            await _articleDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Article>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Article>>(await _articleDal.GetAllAsync(x=>x.Id));
        }

        public async Task<IDataResult<Article>> GetArticleWithCommentsByIdAsync(int id)
        {
            return new SuccessDataResult<Article>(await _articleDal.GetArticleWithCommentsByIdAsync(id));
        }

        public async Task<IDataResult<Article>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Article>(await _articleDal.GetByIdAsync(id));
        }

        public async Task<IResult> UpdateAsync(Article entity)
        {
            await _articleDal.UpdateAsync(entity);
            return new SuccessResult();
        }
    }
}
