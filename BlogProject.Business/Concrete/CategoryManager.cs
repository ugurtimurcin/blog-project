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
    public class CategoryManager :ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IResult> AddAsync(Category entity)
        {
            await _categoryDal.AddAsync(entity);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(Category entity)
        {
            await _categoryDal.DeleteAsync(entity);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetAllAsync(x=>x.Id));
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Category>(await _categoryDal.GetByIdAsync(id));
        }

        public async Task<IResult> UpdateAsync(Category entity)
        {
            await _categoryDal.UpdateAsync(entity);
            return new SuccessResult();
        }
    }
}
