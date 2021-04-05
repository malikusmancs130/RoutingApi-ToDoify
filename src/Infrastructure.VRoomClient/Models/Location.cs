namespace RoutingApi.Infrastructure.VRoomClient.Models
{
    public class Location
    {
        public Location(double lon, double lat)
        {
            Latitude = lat;
            Longitude = lon;
        }
        public double Latitude { get; }
        public double Longitude { get; }
    }
}
