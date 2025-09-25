using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddelbyReolsystemMVVM.Models;

namespace MiddelbyReolsystemMVVM.Repositories
{
    public interface IFileRenterRepository
    {
        IEnumerable<Renter> GetAll();
        Renter GetRenter(Renter renter);
        void AddRenter(Renter renter);
        void UpdateRenter(Renter renter);
        void DeleteRenter(Renter renter);

        void SaveAll(List<Renter> renter);
    }
}
