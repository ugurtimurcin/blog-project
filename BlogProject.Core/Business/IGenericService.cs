using BlogProject.Core.Entities;
using BlogProject.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Business.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        Task<IDataResult<TEntity>> GetByIdAsync(int id);
        Task<IDataResult<List<TEntity>>> GetAllAsync();
        Task<IResult> AddAsync(TEntity entity);
        Task<IResult> UpdateAsync(TEntity entity);
        Task<IResult> DeleteAsync(TEntity entity);
    }
}
