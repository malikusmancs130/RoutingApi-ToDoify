using Microsoft.AspNetCore.Identity;
using RoutingApi.Domain.Common;

namespace RoutingApi.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>, IEntity<int>
    {
    }
}
