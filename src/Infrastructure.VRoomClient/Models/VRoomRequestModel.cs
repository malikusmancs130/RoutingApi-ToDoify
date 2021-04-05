using System.Collections.Generic;

namespace RoutingApi.Infrastructure.VRoomClient.Models
{
    public class VRoomRequestModel
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<Job> Jobs { get; set; }

        public VRoomOption Options { get; set; }
    }
}
