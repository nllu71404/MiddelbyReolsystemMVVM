using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiddelbyReolsystemMVVM.Models
{
    /*
    public enum RackStatus
    {
        Available = 0,
        Occupied = 1,
        Other = 2,
    }
    */

    public class RackStatus
    {
        public static readonly RackStatus Available = new RackStatus(1, "Ledig");
        public static readonly RackStatus Occupied = new RackStatus(2, "Optaget");
        public static readonly RackStatus Other = new RackStatus(3, "Andet");

        public int Id { get; private set; }
        public string Name { get; private set; }

        private RackStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IEnumerable<RackStatus> GetAll()
        {
            return new[] { Available, Occupied, Other };
        }
    }
}
