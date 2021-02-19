using BlogProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlogProject.Core.DataAccess.EntityFramework
{
    public class EfGenericRepository<TEntity, TContext> : IGenericDal<TEntity> 
        where TEntity : class, ITable, new() 
        where TContext: DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new TContext();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new TContext();
            await Task.FromResult(context.Set<TEntity>().Remove(entity));
            await context.SaveChangesAsync();
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, int>> predicate = null)
        {
            using var context = new TContext();
            return predicate == null ? await context.Set<TEntity>().OrderByDescending(predicate).ToListAsync() : await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var context = new TContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new TContext();
            await Task.FromResult(context.Set<TEntity>().Update(entity));
            await context.SaveChangesAsync();
        }
    }
}
