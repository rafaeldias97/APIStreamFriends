using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIStreamFriends.domain.domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        //Async Methods
        Task<IEnumerable<T>> AllAsync();
        T FindBy(Expression<Func<T, bool>> e);
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
