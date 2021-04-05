using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingApi.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> Add(T entity);

        Task<int> Add(IList<T> entities);

        Task<int> Update(T entity);

        Task<int> Update(IList<T> entities);

        Task<int> Delete(T entity);

        Task<int> Delete(IList<T> entities);

        DbSet<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
}