using System.Collections.Generic;

namespace RoutingApi.Infrastructure.VRoomClient.Models.Responses
{
    public class Unassigned
    {
        public int Id { get; set; }
        public List<double> Location { get; set; }
    }
}
