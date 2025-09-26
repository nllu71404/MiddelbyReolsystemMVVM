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

        //Opretter ObservableCollection
        public ObservableCollection<Rack> DisplayedRacks { get; set; }
        public RackService SelectedRack { get; set; }

        public RackViewModel(IFileRackRepository _fileRackRepository)
        {
            this._fileRackRepository = _fileRackRepository;
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
    }
}