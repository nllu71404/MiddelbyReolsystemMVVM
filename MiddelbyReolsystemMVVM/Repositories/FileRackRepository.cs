using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Xml;
using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.Services;
using Newtonsoft.Json;
using Remotion.Linq.Collections;
using Formatting = Newtonsoft.Json.Formatting;


namespace MiddelbyReolsystemMVVM.Repositories
{
    public class FileRackRepository : IFileRackRepository
    {
        private readonly string _filePath;
        private List<Rack> _racks;

        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
        };

         private List<Rack> _predefinedRacks = new List<Rack>
            {
                new Rack(1, RackStatus.Occupied, RackType.Standard),
                new Rack(2, RackStatus.Available, RackType.Premium),
                new Rack(3, RackStatus.Occupied, RackType.Premium),
                new Rack(4, RackStatus.Available, RackType.Standard),
                new Rack(5, RackStatus.Occupied, RackType.Standard),
                new Rack(6, RackStatus.Occupied, RackType.Premium),
                new Rack(7, RackStatus.Available, RackType.Standard),
                new Rack(8, RackStatus.Occupied, RackType.Standard),
                new Rack(9, RackStatus.Occupied, RackType.Premium),
                new Rack(10, RackStatus.Available, RackType.Premium),

                new Rack(11, RackStatus.Occupied, RackType.Standard),
                new Rack(12, RackStatus.Available, RackType.Standard),
                new Rack(13, RackStatus.Occupied, RackType.Premium),
                new Rack(14, RackStatus.Occupied, RackType.Standard),
                new Rack(15, RackStatus.Available, RackType.Premium),
                new Rack(16, RackStatus.Occupied, RackType.Standard),
                new Rack(17, RackStatus.Occupied, RackType.Premium),
                new Rack(18, RackStatus.Available, RackType.Standard),
                new Rack(19, RackStatus.Occupied, RackType.Standard),
                new Rack(20, RackStatus.Occupied, RackType.Premium),

                new Rack(21, RackStatus.Available, RackType.Standard),
                new Rack(22, RackStatus.Occupied, RackType.Standard),
                new Rack(23, RackStatus.Available, RackType.Premium),
                new Rack(24, RackStatus.Occupied, RackType.Premium),
                new Rack(25, RackStatus.Occupied, RackType.Standard),
                new Rack(26, RackStatus.Available, RackType.Standard),
                new Rack(27, RackStatus.Occupied, RackType.Premium),
                new Rack(28, RackStatus.Occupied, RackType.Standard),
                new Rack(29, RackStatus.Available, RackType.Premium),
                new Rack(30, RackStatus.Occupied, RackType.Standard),

                new Rack(31, RackStatus.Occupied, RackType.Premium),
                new Rack(32, RackStatus.Available, RackType.Standard),
                new Rack(33, RackStatus.Occupied, RackType.Standard),
                new Rack(34, RackStatus.Occupied, RackType.Premium),
                new Rack(35, RackStatus.Available, RackType.Standard),
                new Rack(36, RackStatus.Occupied, RackType.Standard),
                new Rack(37, RackStatus.Available, RackType.Premium),
                new Rack(38, RackStatus.Occupied, RackType.Premium),
                new Rack(39, RackStatus.Occupied, RackType.Standard),
                new Rack(40, RackStatus.Available, RackType.Standard),

                new Rack(41, RackStatus.Occupied, RackType.Premium),
                new Rack(42, RackStatus.Occupied, RackType.Standard),
                new Rack(43, RackStatus.Available, RackType.Premium),
                new Rack(44, RackStatus.Occupied, RackType.Standard),
                new Rack(45, RackStatus.Occupied, RackType.Premium),
                new Rack(46, RackStatus.Available, RackType.Standard),
                new Rack(47, RackStatus.Occupied, RackType.Standard),
                new Rack(48, RackStatus.Occupied, RackType.Premium),
                new Rack(49, RackStatus.Available, RackType.Standard),
                new Rack(50, RackStatus.Occupied, RackType.Standard),

                new Rack(51, RackStatus.Available, RackType.Premium),
                new Rack(52, RackStatus.Occupied, RackType.Standard),
                new Rack(53, RackStatus.Occupied, RackType.Premium),
                new Rack(54, RackStatus.Available, RackType.Standard),
                new Rack(55, RackStatus.Occupied, RackType.Standard),
                new Rack(56, RackStatus.Occupied, RackType.Premium),
                new Rack(57, RackStatus.Available, RackType.Premium),
                new Rack(58, RackStatus.Occupied, RackType.Standard),
                new Rack(59, RackStatus.Occupied, RackType.Premium),
                new Rack(60, RackStatus.Available, RackType.Standard),

                new Rack(61, RackStatus.Occupied, RackType.Standard),
                new Rack(62, RackStatus.Available, RackType.Premium),
                new Rack(63, RackStatus.Occupied, RackType.Premium),
                new Rack(64, RackStatus.Occupied, RackType.Standard),
                new Rack(65, RackStatus.Available, RackType.Standard),
                new Rack(66, RackStatus.Occupied, RackType.Premium),
                new Rack(67, RackStatus.Occupied, RackType.Standard),
                new Rack(68, RackStatus.Available, RackType.Premium),
                new Rack(69, RackStatus.Occupied, RackType.Standard),
                new Rack(70, RackStatus.Occupied, RackType.Premium),

                new Rack(71, RackStatus.Available, RackType.Standard),
                new Rack(72, RackStatus.Occupied, RackType.Standard),
                new Rack(73, RackStatus.Occupied, RackType.Premium),
                new Rack(74, RackStatus.Available, RackType.Premium),
                new Rack(75, RackStatus.Occupied, RackType.Standard),
                new Rack(76, RackStatus.Occupied, RackType.Premium),
                new Rack(77, RackStatus.Available, RackType.Standard),
                new Rack(78, RackStatus.Occupied, RackType.Standard),
                new Rack(79, RackStatus.Other, RackType.Premium),
                new Rack(80, RackStatus.Available, RackType.Premium),

             };


        

        public FileRackRepository(string filePath)
        {
            
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                // Førstegang → gem de predefinerede racks til fil
                _racks = new List<Rack>(_predefinedRacks);
                SaveAll(_racks);
            }
            else
            {
                var json = File.ReadAllText(_filePath);
                _racks = JsonConvert.DeserializeObject<List<Rack>>(json, _jsonSettings) ?? new List<Rack>(_predefinedRacks);

                // Hvis filen er tom, seed igen
                if (_racks.Count == 0)
                {
                    _racks = new List<Rack>(_predefinedRacks);
                    SaveAll(_racks);
                }
            }
        }

        public IEnumerable<Rack> GetAll()
        {
            return _racks;
        }

        public IEnumerable<Rack> GetRacksByStatus(RackStatus status)
        {
            //Debug
            MessageBox.Show($"Søger efter status: Id={status.Id}, Name={status.Name}");

            var result = _racks.Where(r => r.RackStatus?.Id == status.Id).ToList();
            /*
            // DEBUG: Print hvad hver rack har
            foreach (var rack in _racks.Take(5)) // Kun de første 5 for ikke at spamme
            {
                Console.WriteLine($"Rack {rack.RackNumber}: Status Id={rack.RackStatus?.Id}, Name={rack.RackStatus?.Name}");
            }

            var result = _racks.Where(r => r.RackStatus?.Id == status.Id);

            Console.WriteLine($"Fandt {result} racks");

            return result;
            */

            MessageBox.Show($"Fandt {result.Count} racks");

            return result;
        }


        public void UpdateRackStatus(int RackNumber, RackStatus newStatus)
        {
            var racks = _racks.FirstOrDefault(r => r.RackNumber == RackNumber);

            if (_racks == null)
            {
                throw new KeyNotFoundException($"Reol {RackNumber} findes ikke");
            }

            racks.RackStatus = newStatus;
            SaveAll(_racks);
        }
        //public List<Rack> GetAll() => _racks;
        /*
        public IEnumerable<Rack> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Rack>();
            }
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Rack>>(json, _jsonSettings) ?? new List<Rack> { };
        }
        */

        public Rack GetRack(Rack rack)
        {
            GetAll().FirstOrDefault(r => r.RackNumber == rack.RackNumber);      // Returnerer alle rackobjekter, og søger gennem collectionen efter et rack med samme RackNumber som det givne rack
            throw new NotImplementedException();
        }

        public void AddRack(Rack rack)
        {
            var racks = GetAll().ToList();
            racks.Add(rack);
            SaveAll(_racks);
        }

        public void DeleteRack(Rack rack)
        {
            var racks = GetAll().ToList();
            racks.RemoveAll(r => r.RackNumber == rack.RackNumber);
            SaveAll(_racks);
        }

        public void UpdateRack(Rack rack)
        {
            var racks = GetAll().ToList();
            var index = racks.FindIndex(r => r.RackNumber == rack.RackNumber);
            if (index == -1) throw new KeyNotFoundException("Reolnummer blev ikke fundet");

            racks[index] = rack;
            SaveAll(_racks);
        }
        public void SaveAll(List<Rack> racks)
        {
            var json = JsonConvert.SerializeObject(racks, _jsonSettings);
            File.WriteAllText(_filePath, json);
        }

        
    }
}
