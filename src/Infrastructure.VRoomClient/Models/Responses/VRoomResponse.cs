using System.Collections.Generic;

namespace RoutingApi.Infrastructure.VRoomClient.Models.Responses
{
    public class VRoomResponse
    {
        public int Code { get; set; }
        public Summary Summary { get; set; }
        public List<Unassigned> Unassigned { get; set; }
        public List<Route> Routes { get; set; }
    }
}