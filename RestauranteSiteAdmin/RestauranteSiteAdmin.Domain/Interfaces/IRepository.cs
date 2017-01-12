using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestauranteSiteAdmin.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<bool> Insert(T t);
        Task<bool> Update(string id, T t);
        Task<T> GetById(string id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Func<T, bool> predicate);
        Task<bool> Delete(string id);
    }
}
