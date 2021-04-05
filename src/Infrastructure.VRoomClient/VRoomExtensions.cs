using RoutingApi.Infrastructure.VRoomClient.Models;
using System.Collections.Generic;

namespace RoutingApi.Infrastructure.VRoomClient
{
    public static class VRoomExtensions
    {
        public static List<double> ConvertToArray(this Location location)
        {
            if (location == null) return new List<double>();

            return new List<double>()
            {
                location.Longitude,
                location.Latitude
            };
        }
    }
}
