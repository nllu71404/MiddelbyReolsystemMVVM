using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
        };

        public RackService rackService;

        public FileRackRepository(string filePath, RackService rackservice)
        {
            rackService = rackservice;
            _filePath = filePath;
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public IEnumerable<Rack> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Rack>();
            }
            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Rack>>(json, _jsonSettings) ?? new List<Rack> { };
        }

        public Rack GetRack(Rack rack)
        {
            GetAll().FirstOrDefault(r => r.RackNumber == rack.RackNumber);      // Returnerer alle rackobjekter, og søger gennem collectionen efter et rack med samme RackNumber som det givne rack
            throw new NotImplementedException();
        }

        public void AddRack(Rack rack)
        {
            var racks = GetAll().ToList();
            racks.Add(rack);
            SaveAll(racks);
        }

        public void DeleteRack(Rack rack)
        {
            var racks = GetAll().ToList();
            racks.RemoveAll(r => r.RackNumber == rack.RackNumber);
            SaveAll(racks);
        }

        public void UpdateRack(Rack rack)
        {
            var racks = GetAll().ToList();
            var index = racks.FindIndex(r => r.RackNumber == rack.RackNumber);
            if (index != -1) throw new KeyNotFoundException("Reolnummer blev ikke fundet");

            racks[index] = rack;
            SaveAll(racks);
        }
        public void SaveAll(List<Rack> racks)
        {
            var json = JsonConvert.SerializeObject(racks, _jsonSettings);
            File.WriteAllText(_filePath, json);
        }

        public IEnumerable<Rack> GetRacksByStatus(RackStatus status)
        {
            return rackService._predefinedRacks.Where(r => r.RackStatus == status);
        }

        public void UpdateRack(RackService selectedRack)
        {
            throw new NotImplementedException();
        }
    }
}
