using BlogProject.DataAccess.Abstract;
using BlogProject.DataAccess.Concrete.Context;
using BlogProject.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DataAccess.Concrete.Repositories.EfRepositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new BlogContext();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new BlogContext();
            await Task.FromResult(context.Set<TEntity>().Remove(entity));
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new BlogContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, int>>predicate)
        {
            using var context = new BlogContext();
            return await context.Set<TEntity>().OrderByDescending(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var context = new BlogContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new BlogContext();
            await Task.FromResult(context.Set<TEntity>().Update(entity));
            await context.SaveChangesAsync();
        }
    }
}
