using BlogProject.Business.Abstract;
using BlogProject.DataAccess.Abstract;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Concrete
{
    public class ArticleManager : GenericManager<Article>, IArticleService
    {
        private readonly IGenericDal<Article> _genericDal;
        private readonly IArticleDal _articleDal;
        public ArticleManager(IGenericDal<Article> genericDal, IArticleDal articleDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _articleDal = articleDal;
        }

        public async Task<Article> GetArticleWithCommentsByIdAsync(int id)
        {
            return await _articleDal.GetArticleWithCommentsByIdAsync(id);
        }
    }
}
