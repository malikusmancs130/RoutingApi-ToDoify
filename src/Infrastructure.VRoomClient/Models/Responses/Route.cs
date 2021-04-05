using System.Collections.Generic;

namespace RoutingApi.Infrastructure.VRoomClient.Models.Responses
{
    public class Route
    {
        public int Vehicle { get; set; }
        public int Cost { get; set; }
        public int Service { get; set; }
        public int Duration { get; set; }
        public int Waiting_time { get; set; }
        public int Sistance { get; set; }
        public List<Step> Steps { get; set; }
        public string Geometry { get; set; }
    }
}
