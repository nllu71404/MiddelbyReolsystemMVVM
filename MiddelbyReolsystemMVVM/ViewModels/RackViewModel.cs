using System;
using System.Collections.ObjectModel;
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
            Renters = adminRenterViewModel.Renters;
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

        // Tildeler den valgte lejer til det valgte reolsystem (rack).
        // Opdaterer reolen i repository og informerer UI om ændringen.
        public void AssignRenterToSelectedRack()
        {
            if (SelectedRack != null && SelectedRenter != null)
            {
                // Tildeler Renter til Reol
                SelectedRack.Renter = SelectedRenter;

                //Opdaterer fra Ledig til optaget
                SelectedRack.RackStatus = RackStatus.Occupied;

                // Gemmer den opdaterede Rack i repository
                _fileRackRepository.UpdateRack(SelectedRack);

                var filteredRacks = _currentFilter != null
                    ? _fileRackRepository.GetRacksByStatus(_currentFilter)
                    : _fileRackRepository.GetAll();

                UpdateDisplayedRacks(filteredRacks);

                //Sender besked til UI
                OnPropertyChanged(nameof(SelectedRack));
                OnPropertyChanged(nameof(DisplayedRacks));


                /*
                //Hent tidligere filer
                if (_currentFilter != null)
                {
                    var filteredRacks = _fileRackRepository.GetRacksByStatus(_currentFilter);
                    UpdateDisplayedRacks(filteredRacks);
                }
                */



            }
        }

        // Fjerner lejeren fra det valgte reolsystem (rack).
        // Opdaterer reolen i repository og informerer UI om ændringen.
        public void RemoveRenterFromSelectedRack()
        {
            if (SelectedRack != null)
            {
                // Fjerner lejeren fra SelectedRack
                SelectedRack.Renter = null;

                //Opdaterer fra Optaget til Ledig
                SelectedRack.RackStatus = RackStatus.Available;

                // Opdaterer rack i repository
                _fileRackRepository.UpdateRack(SelectedRack);

                // Informerer UI om at SelectedRack er ændret
                OnPropertyChanged(nameof(SelectedRack));
                OnPropertyChanged(nameof(DisplayedRacks));
            }
        }
    }
}