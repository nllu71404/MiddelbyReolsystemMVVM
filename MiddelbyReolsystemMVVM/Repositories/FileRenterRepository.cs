using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.Services;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;


namespace MiddelbyReolsystemMVVM.Repositories
{
    public class FileRenterRepository : IFileRenterRepository
    {
        private readonly string _filepathRenter;
        private List<Renter> _renters;

        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
        };
        public RenterService renterService;

        public FileRenterRepository(string filepathRenter)
        {
            _filepathRenter = filepathRenter;
            if (!File.Exists(_filepathRenter))
            {
                File.WriteAllText(_filepathRenter, "[]");
            }
            else
            {
                var json = File.ReadAllText(_filepathRenter);
                _renters = JsonConvert.DeserializeObject<List<Renter>>(json, _jsonSettings) ?? new List<Renter>();
                System.Diagnostics.Debug.WriteLine($"LOADET {_renters.Count} renters fra fil");
            }
        }


        public IEnumerable<Renter> GetAll()
        {
            if (!File.Exists(_filepathRenter))
            {
                return new List<Renter>();
            }
            var json = File.ReadAllText(_filepathRenter);
            return JsonConvert.DeserializeObject<List<Renter>>(json, _jsonSettings) ?? new List<Renter> { };
        }
        public Renter GetRenter(Renter renter)
        {
            GetAll().FirstOrDefault(r=> r.Id == renter.Id);
            return renter;
        }

        public void AddRenter(Renter renter)
        {
           
            // Id sættes automatisk i din Renter-konstruktør (med _nextId++) - Derfor indeholder metoden ikke logik, der opretter ID
            var renters = GetAll().ToList();
            renters.Add(renter);
            SaveAll(renters);
        }

        public void DeleteRenter(Renter renter)
        {
            System.Diagnostics.Debug.WriteLine($"INDEN DELETE: {_renters.Count} renters");
            System.Diagnostics.Debug.WriteLine($"Sletter renter med Id: {renter.Id}");

            // Slet DIREKTE fra _renters
            _renters.RemoveAll(r => r.Id == renter.Id);

            System.Diagnostics.Debug.WriteLine($"EFTER DELETE: {_renters.Count} renters");

            // Gem den opdaterede _renters liste
            SaveAll(_renters);
        }
        
        public void UpdateRenter(Renter renter)
        {

            if (renter == null) throw new ArgumentNullException(nameof(renter)); 
            var renters = GetAll().ToList();
            var index = renters.FindIndex(r => r.Id == renter.Id);
            if (index == -1) throw new KeyNotFoundException($"Renter med Id {renter.Id} findes ikke");
            renters[index] = renter;
            SaveAll(renters);

        }

        public void SaveAll(List<Renter> renters)
        {
            var json = JsonConvert.SerializeObject(renters, _jsonSettings);
            File.WriteAllText(_filepathRenter, json);
        }
    }
}