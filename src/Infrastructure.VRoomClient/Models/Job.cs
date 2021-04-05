using Newtonsoft.Json;

namespace RoutingApi.Infrastructure.VRoomClient.Models
{
    public class Job
    {
        public int Id { get; set; }

        [JsonConverter(typeof(CustomArrayConverter))]
        public Location Location { get; set; }

    }

}
