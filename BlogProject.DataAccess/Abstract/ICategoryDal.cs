using BlogProject.Core.DataAccess;
using BlogProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccess.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
    }
}
