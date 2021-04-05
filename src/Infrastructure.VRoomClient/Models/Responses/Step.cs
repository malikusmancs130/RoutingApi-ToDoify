using Newtonsoft.Json;

namespace RoutingApi.Infrastructure.VRoomClient.Models.Responses
{
    public class Step
    {
        public string Type { get; set; }
       // public List<double> Location { get; set; }
        [JsonConverter(typeof(CustomArrayConverter))]
        public Location Location { get; set; }
        public int Arrival { get; set; }
        public int Duration { get; set; }
        public int Distance { get; set; }
        public int? Id { get; set; }
        public int? Service { get; set; }
        public int? Waiting_time { get; set; }
        public int? Job { get; set; }
    }
}
