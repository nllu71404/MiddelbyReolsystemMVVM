using System.Collections.Generic;
using MiddelbyReolsystemMVVM.Models;

namespace MiddelbyReolsystemMVVM.Services
{
    public class RackService : IRackService
    {
        public IEnumerable<Rack> GetPredefinedRacks()
        {
            return new List<Rack>
{
            new Rack(1, RackStatus.Available, RackType.RackWithShelves),
            new Rack(2, RackStatus.Occupied,  RackType.RackWithShelves),
            new Rack(3, RackStatus.Available, RackType.RackWithHangers),
            new Rack(4, RackStatus.Occupied,  RackType.RackWithHangers),
            new Rack(5, RackStatus.Other,     RackType.RackWithShelves),
            new Rack(6, RackStatus.Available, RackType.RackWithHangers)
            };
        }
    }
}
