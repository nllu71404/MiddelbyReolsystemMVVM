using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace MiddelbyReolsystemMVVM.Models
{
    //[Newtonsoft.Json.JsonConverter(typeof(RackStatusJsonConverter))]
    public class RackStatus
    {
        public static readonly RackStatus Available = new RackStatus(1, "Ledig");
        public static readonly RackStatus Occupied = new RackStatus(2, "Optaget");
        public static readonly RackStatus Other = new RackStatus(3, "Andet");

        public int Id { get; set; }
        public string Name { get; set; }

        public RackStatus() { }

        public RackStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }
        /*
        public static IEnumerable<RackStatus> GetAll()
        {
            return new[] { Available, Occupied, Other };
        }
        */

        public override bool Equals(object obj)
        {
            if (obj is RackStatus other)
            {
                return Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
