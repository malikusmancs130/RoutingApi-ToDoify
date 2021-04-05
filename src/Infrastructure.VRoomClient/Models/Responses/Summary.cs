
namespace RoutingApi.Infrastructure.VRoomClient.Models.Responses
{
    public class Summary
    {
        public int Cost { get; set; }
        public int Unassigned { get; set; }
        public int Service { get; set; }
        public int Duration { get; set; }
        public int Waiting_time { get; set; }
        public int Distance { get; set; }
        public ComputingTimes Computing_times { get; set; }
    }
}
