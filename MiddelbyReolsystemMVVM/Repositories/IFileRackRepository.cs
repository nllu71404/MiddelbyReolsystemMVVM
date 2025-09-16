using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddelbyReolsystemMVVM.Models;

namespace MiddelbyReolsystemMVVM.Repositories
{
    public interface IFileRackRepository
    {
        IEnumerable<Rack> GetAll();
        Rack GetRack(Rack rack);
        void AddRack(Rack rack);
        void UpdateRack(Rack rack);
        void DeleteRack(Rack rack);

        void SaveAll(IEnumerable<Rack> racks);
    }
}
