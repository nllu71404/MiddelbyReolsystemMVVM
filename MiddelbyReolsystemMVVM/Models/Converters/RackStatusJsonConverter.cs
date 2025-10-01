using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MiddelbyReolsystemMVVM.Models.Converters
{
    /*public  class RackStatusJsonConverter : JsonConverter<RackStatus>
    {
        public override void WriteJson(JsonWriter writer, RackStatus value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Id");
            writer.WriteValue(value.Id);
            writer.WritePropertyName("Name");
            writer.WriteValue(value.Name);
            writer.WriteEndObject();
        }

        public override RackStatus ReadJson(JsonReader reader, Type objectType, RackStatus existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            int id = obj["Id"].Value<int>();

            return id switch
            {
                1 => RackStatus.Available,
                2 => RackStatus.Occupied,
                3 => RackStatus.Other,
                _ => RackStatus.Other
            };
        }
    }
    */
}
