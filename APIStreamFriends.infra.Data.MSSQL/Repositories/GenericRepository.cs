using APIStreamFriends.domain.domain.Interfaces;
using APIStreamFriends.infra.Data.MSSQL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIStreamFriends.infra.Data.MSSQL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> entity_;
        protected MSContext context;

        public GenericRepository(MSContext context)
        {
            this.context = context;
            entity_ = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await entity_.ToListAsync();
        }

        public virtual T FindBy(Expression<Func<T, bool>> e)
        {
            return entity_.Where(e).FirstOrDefault();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            entity_.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            entity_.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            context.Attach(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
    }
}
