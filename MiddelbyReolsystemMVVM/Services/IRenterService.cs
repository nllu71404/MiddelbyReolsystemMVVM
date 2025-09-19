using MiddelbyReolsystemMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddelbyReolsystemMVVM.Services
{
    public interface IRenterService
    {
        IEnumerable<Renter> GetAllRenters();
        void AddRenter(Renter renter);
        void UpdateRenter(Renter renter);
        void DeleteRenter(int renterId);
    }
}
