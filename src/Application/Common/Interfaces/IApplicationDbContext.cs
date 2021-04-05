using Microsoft.EntityFrameworkCore;
using RoutingApi.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RoutingApi.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Todo> Todos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}