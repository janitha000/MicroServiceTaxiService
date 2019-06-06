using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaxiMicroService.Drivers.Entities;

namespace TaxiMicroService.Drivers.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase, new()
    {
        private DatabaseContext _context;

        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            await _context.Set<T>().AddAsync(entity);
            await Commit();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
            await Commit();
        }

        public async Task DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
            await Commit();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public async Task<List<T>> GetAll()
        {
            List<T> entities = await _context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetSingle(string id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            return entity;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await Commit();
        }
    }

}
