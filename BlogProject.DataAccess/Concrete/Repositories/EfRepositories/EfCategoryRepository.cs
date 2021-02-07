using BlogProject.Core.DataAccess.EntityFramework;
using BlogProject.DataAccess.Abstract;
using BlogProject.DataAccess.Concrete.Context;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccess.Concrete.Repositories.EfRepositories
{
    public class EfCategoryRepository : EfGenericRepository<Category, BlogContext>, ICategoryDal
    {
    }
}
