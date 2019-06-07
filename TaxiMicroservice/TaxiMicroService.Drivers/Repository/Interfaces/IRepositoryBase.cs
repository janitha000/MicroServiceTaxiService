using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaxiMicroService.Drivers.Entities;

namespace TaxiMicroService.Drivers.Repository
{
    public interface IRepositoryBase<T> where T : class, IEntityBase, new()
    {
        Task<List<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task DeleteWhere(Expression<Func<T, bool>> predicate);
        Task Commit();
    }

}
