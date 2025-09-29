using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.Services;

namespace MiddelbyReolsystemMVVM.Repositories
{
    public interface IFileRackRepository
    {
        public IEnumerable<Rack> GetAll();
        Rack GetRack(Rack rack);
        void AddRack(Rack rack);
        void UpdateRack(Rack rack);
        void DeleteRack(Rack rack);

        void SaveAll(List<Rack> racks);
        public IEnumerable<Rack> GetRacksByStatus(RackStatus status);
        
        void UpdateRackStatus(int RackNumber, RackStatus newStatus);
    }
}
