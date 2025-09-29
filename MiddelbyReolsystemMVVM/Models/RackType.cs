using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddelbyReolsystemMVVM.Models
{
    /*
    public enum RackType
    {
        RackWithShelves = 0,
        RackWithHangers = 1,
    }
    */
    public class RackType
    {
        public static readonly RackType Standard = new RackType(1, "Med hylder");
        public static readonly RackType Premium = new RackType(2, "Med bøjle");

        public int Id { get; private set; }
        public string Name { get; private set; }

        public RackType() { }
        private RackType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static IEnumerable<RackType> GetAll()
        {
            return new[] { Standard, Premium };
        }

        public override bool Equals(object obj)
        {
            if (obj is RackType other)
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

