using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.Repositories;
using MiddelbyReolsystemMVVM.ViewModels;
using MiddelbyReolsystemMVVM.Views;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class RackViewModel : BaseViewModel
    {
        //private readonly RackService _rackService;
        public IFileRackRepository _fileRackRepository;

        // Hvilken knap er aktiv
        private RackStatus _currentFilter = null;

        //Opretter ObservableCollection
        public ObservableCollection<Rack> _displayedRacks;
        public Rack SelectedRack { get; set; }
        public ObservableCollection<Renter> Renters { get; set; }
        public Renter SelectedRenter { get; set; }

        public ObservableCollection<Rack> DisplayedRacks
        {
            get => _displayedRacks;
            set
            {
                _displayedRacks = value;
                OnPropertyChanged(nameof(DisplayedRacks));
            }
        }

        public RackViewModel(IFileRackRepository fileRackRepository, AdminRenterViewModel adminRenterViewModel)
        {
            this._fileRackRepository = fileRackRepository;
            
            DisplayedRacks = new ObservableCollection<Rack>();
            //Undgå null expression, så programmet ikke crasher
            Renters = adminRenterViewModel?.Renters ?? new ObservableCollection<Renter>(); 
            
        }

        public void OpenRackOverview()
        {
            var rackOverview = new RackOverview();
            rackOverview.Show();
        }

        public void OpenAdminRenterView()
        {
            var adminRenterView = new AdminRenterView();
            adminRenterView.Show();
        }

        public void OpenAdminRackView()
        {
            var adminRackView = new AdminRackView();
            adminRackView.Show();
        }
        public void ExecuteShowLedige(object parameter)
        {
            var ledigeRacks = _fileRackRepository.GetRacksByStatus(RackStatus.Available);
            UpdateDisplayedRacks(ledigeRacks);
        }
        public void ExecuteShowOptaget(object parameter)
        {
            var optagetRacks = _fileRackRepository.GetRacksByStatus(RackStatus.Occupied);
            UpdateDisplayedRacks(optagetRacks);
        }

        public void ExecuteShowAndet(object parameter)
        {
            var andetRacks = _fileRackRepository.GetRacksByStatus(RackStatus.Other);
            UpdateDisplayedRacks(andetRacks);
        }

        public void ShowAvailableRacks()
        {
            _currentFilter = RackStatus.Available;
            var racks = _fileRackRepository.GetRacksByStatus(RackStatus.Available);
            UpdateDisplayedRacks(racks);
        }
        
        private void UpdateDisplayedRacks(IEnumerable<Rack> racks)
        {
            var rackList = racks.ToList();

            DisplayedRacks.Clear();
            foreach(var rack in rackList)
            {
                DisplayedRacks.Add(rack);
            }
        }
        
        private void RefreshSingleRack(Rack rack)
        {
            if (rack == null) return;

            // Findes racket på listen
            var existing = DisplayedRacks.FirstOrDefault(r => r.RackNumber == rack.RackNumber);

            // Bestemmer om Rack skal vises i det aktuelle filter
            bool matchesFilter = _currentFilter == null || rack.RackStatus == _currentFilter;

            if (existing != null && !matchesFilter)
            {
                // Sletter et Rack fra listen hvis det ikke matcher filteret
                DisplayedRacks.Remove(existing);
            }
            else if (existing == null && matchesFilter)
            {
                // Tilføjer Rack til listen der matcher filteret
                DisplayedRacks.Add(rack);
            }
            else if (existing != null && matchesFilter)
            {
                // Opdateret UI hvis DisplayedRack matcher filteret
                int index = DisplayedRacks.IndexOf(existing);
                DisplayedRacks[index] = rack; // Triggerer UI opdatering
            }
        }
        //Tildeler Lejer til Reol
        public void AssignRenterToSelectedRack()
        {
            if (SelectedRack == null || SelectedRenter == null)
                return;

            SelectedRack.Renter = SelectedRenter;
            SelectedRack.RackStatus = RackStatus.Occupied;

            _fileRackRepository.UpdateRack(SelectedRack);

            // Opdater kun denne rack i UI
            RefreshSingleRack(SelectedRack);

            // Informerer UI om SelectedRack
            OnPropertyChanged(nameof(SelectedRack));
        }

        // Fjerner lejer fra SelectedRack
        public void RemoveRenterFromSelectedRack()
        {
            if (SelectedRack == null)
                return;

            SelectedRack.Renter = null;
            SelectedRack.RackStatus = RackStatus.Available;

            _fileRackRepository.UpdateRack(SelectedRack);

            // Opdater kun denne rack i UI
            RefreshSingleRack(SelectedRack);

            // Informerer UI om SelectedRack
            OnPropertyChanged(nameof(SelectedRack));
        }
    }
}