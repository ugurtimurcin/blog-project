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
        public ArticleManager(IGenericDal<Article> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }
    }
}
