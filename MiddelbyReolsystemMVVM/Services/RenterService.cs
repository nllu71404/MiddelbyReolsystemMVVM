using MiddelbyReolsystemMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddelbyReolsystemMVVM.Services
{
    public class RenterService 
    {

        private static RenterService? _instance;
        public static RenterService Instance()
        {
            if (_instance == null)
            {
                _instance = new RenterService();
            }
            return _instance;
        }

        // Prædefineret liste med lejere
        public List<Renter> renters = new()
        {
            new Renter("Jens", "Hansen", "jegharenbondegaard@flex.dk", "23559356", "1234567890", true),
            new Renter("Gerda", "Jensen", "gerdajens@email.dk", "94113737", "2345921536", true),
        };

        public IEnumerable<Renter> GetAllRenters() => renters;

        public Renter? GetById(int renterId) => renters.FirstOrDefault(r => r.Id == renterId);

        public void AddRenter(Renter renter)
        {
            if (renter == null) return;
            // Id sættes automatisk i din Renter-konstruktør (med _nextId++)
            renters.Add(renter);
        }

        public void UpdateRenter(Renter renter)
        {
            if (renter == null) return;
            var existing = renters.FirstOrDefault(r => r.Id == renter.Id);
            if (existing == null) return;

            // Opdater felter
            existing.FirstName = renter.FirstName;
            existing.LastName = renter.LastName;
            existing.Email = renter.Email;
            existing.PhoneNumber = renter.PhoneNumber;
            existing.BankInformation = renter.BankInformation;
            existing.ConsentGiven = renter.ConsentGiven;
        }

        public void DeleteRenter(int renterId)
        {
            renters.RemoveAll(r => r.Id == renterId);
        }
    }
}
