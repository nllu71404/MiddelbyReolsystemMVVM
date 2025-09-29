using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.Repositories;
using MiddelbyReolsystemMVVM.Services;
using MiddelbyReolsystemMVVM.ViewModels;
using MiddelbyReolsystemMVVM.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class RackViewModel : BaseViewModel
    {
        //private readonly RackService _rackService;
        public IFileRackRepository _fileRackRepository;
        public IFileRenterRepository _fileRenterRepository;

        //Opretter ObservableCollection
        public ObservableCollection<Rack> DisplayedRacks { get; set; }
        public RackService SelectedRack { get; set; }
        public ObservableCollection<Renter> Renters { get; set; }
        public Renter SelectedRenter { get; set; }


        public RackViewModel(IFileRackRepository fileRackRepository, AdminRenterViewModel adminRenterViewModel)
        {
            _fileRackRepository = fileRackRepository;
            Renters = new ObservableCollection<Renter>();
            DisplayedRacks = new ObservableCollection<Rack>();
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
        
        private void UpdateDisplayedRacks(IEnumerable<Rack> racks)
        {
            var rackList = racks.ToList();
            DisplayedRacks = new ObservableCollection<Rack>(rackList);

            OnPropertyChanged(nameof(DisplayedRacks));
            

            
        }

        // Tildeler den valgte lejer til det valgte reolsystem (rack).
        // Opdaterer reolen i repository og informerer UI om ændringen.
        public void AssignRenterToSelectedRack()
        {
            if (SelectedRack != null && SelectedRenter != null)
            {
                // Sætter SelectedRenter som lejer på SelectedRack
                SelectedRack.Renter = SelectedRenter;
                // Opdaterer rack i repository
                _fileRackRepository.UpdateRack(SelectedRack);
                // Informerer UI om at SelectedRack er ændret
                OnPropertyChanged(nameof(SelectedRack));
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
                // Opdaterer rack i repository
                _fileRackRepository.UpdateRack(SelectedRack);
                // Informerer UI om at SelectedRack er ændret
                OnPropertyChanged(nameof(SelectedRack));
            }
        }
    }
}