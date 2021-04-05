using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RoutingApi.Infrastructure.VRoomClient.Models;
using RoutingApi.Infrastructure.VRoomClient.Models.Responses;

namespace RoutingApi.Infrastructure.VRoomClient
{
    public class VRoomClient
    {
        public string Execute(string requestModel)
        {
            var client = new RestClient(" http://solver.vroom-project.org");
            var request = new RestRequest("", Method.POST);
            request.RequestFormat = DataFormat.Json;


            var model = GetVRoomRequestModel();

            var response = CallVRoom(model, request, client);

            var objectItem = Newtonsoft.Json.JsonConvert.DeserializeObject<VRoomResponse>(response.Content);

            return response.Content;
        }

        private IRestResponse CallVRoom(object model, RestRequest request, RestClient client)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jsonModel = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
            request.AddHeader("Content-type", "application/json");

            // var jsonModel = File.ReadAllText(@"C:\Users\shakeel.iqbal\source\repos\VRoomTest\test-time.json");

            request.AddBody(jsonModel);

            var response = client.Execute(request);
            return response;
        }

        private static object GetVRoomRequestModel()
        {
            var model = new VRoomRequestModel
            {
                Vehicles = new List<Vehicle>
                {
                    new Vehicle
                    {
                        Id = 1,
                        Start = new Location(11.45394787, 54.70191545),
                        End = new Location(11.45394787, 54.70191545)
                    }
                },
                Jobs = new List<Job>
                {
                    new Job {Id = 1, Location = new Location(11.48143053, 54.74498234)},
                    new Job {Id = 1, Location = new Location(11.60158739, 54.72278386)},
                    new Job {Id = 1, Location = new Location(11.62690583, 54.69713754)}
                },

                Options = new VRoomOption
                {
                    G = true
                }
            };
            return model;
        }
    }

   
   


    
}
