using Microsoft.EntityFrameworkCore;
using RoutingApi.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingApi.Persistence
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Private Members

        private readonly ApplicationDbContext _context;
        private DbSet<T> _entities;

        #endregion Private Members

        #region Properties

        protected virtual DbSet<T> Entities => _entities ??= _context.Set<T>();

        public DbSet<T> Table => Entities;

        public IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        #endregion Properties

        #region Constructors

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            //_context.ChangeTracker.LazyLoadingEnabled = false;
        }

        #endregion Constructors

        #region Methods

        public async Task<int> Add(T entity)
        {
            await Entities.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Add(IList<T> entities)
        {
            await Entities.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(IList<T> entities)
        {
            _context.UpdateRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            Entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(IList<T> entities)
        {
            Entities.RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        #endregion Methods
    }
}