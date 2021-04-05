using Newtonsoft.Json;

namespace RoutingApi.Infrastructure.VRoomClient.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [JsonConverter(typeof(CustomArrayConverter))]
        public Location Start { get; set; }

        [JsonConverter(typeof(CustomArrayConverter))]
        public Location End { get; set; }

    }
}
