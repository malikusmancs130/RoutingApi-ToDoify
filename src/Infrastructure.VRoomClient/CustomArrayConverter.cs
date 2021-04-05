using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RoutingApi.Infrastructure.VRoomClient.Models;

namespace RoutingApi.Infrastructure.VRoomClient
{

    public class CustomArrayConverter : JsonConverter<Location>
    {
        public override void WriteJson(JsonWriter writer, Location value, JsonSerializer serializer)
        {

            var array = value.ConvertToArray();
            JToken t = JToken.FromObject(array);


            t.WriteTo(writer);
        }

        public override Location ReadJson(JsonReader reader, Type objectType, Location existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {

            var myCustomType = new Location(0, 0);
         //   if (reader.Value == null) return new Location(0, 0);

           // return new Location(0,0);

            if (reader.TokenType != JsonToken.Null)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    JToken token = JToken.Load(reader);
                    List<double> items = token.ToObject<List<double>>();

                    if (items.Count == 2)
                    {
                        myCustomType = new Location(items[0], items[1]);
                    }

                }
                else
                {
                    JValue jValue = new JValue(reader.Value);
                    //switch (reader.TokenType)
                    //{
                    //    case JsonToken.String:
                    //        myCustomType = new Location((string)jValue);
                    //        break;
                    //    case JsonToken.Date:
                    //        myCustomType = new MyCustomType((DateTime)jValue);
                    //        breakLocation
                    //    case JsonToken.Boolean:
                    //        myCustomType = new MyCustomType((bool)jValue);
                    //        break;
                    //    case JsonToken.Integer:
                    //        int i = (int)jValue;
                    //        myCustomType = new MyCustomType(i);
                    //        break;
                    //    default:
                    //        Console.WriteLine("Default case");
                    //        Console.WriteLine(reader.TokenType.ToString());
                    //        break;
                    //}
                }
            }

            return myCustomType;
        }
    }
}
