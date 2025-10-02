using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MiddelbyReolsystemMVVM.Models
{
    public class Rack
    {
        public int RackNumber { get; set; }
        public RackStatus RackStatus { get; set; }
        public RackType RackType { get; set; }
        public Renter Renter { get; set; }

        //Nødvendig for JSON deserialisering
        public Rack()
        {

        }
        public Rack(int rackNumber, RackStatus rackStatus, RackType rackType)
        {
            RackNumber = rackNumber;
            RackStatus = rackStatus;
            RackType = rackType;
        }
    }
}
