using MiddelbyReolsystemMVVM.Models;
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
        private readonly RackService _rackService;

        //Opretter ObservableCollection
        public ObservableCollection<Rack> DisplayedRacks { get; set; }
        public RackService SelectedRack { get; set; }

        //Opretter Commands
        public ICommand ShowLedigeCommand { get; private set; }
        public ICommand ShowOptagetCommand { get; private set; }
        public ICommand ShowAndetCommand { get; private set; }
        
        public ICommand GoAdminRenter { get; }
        public ICommand GoAdminRack { get; }

        public RackViewModel(RackService rackservice)
        {
            _rackService = rackservice;
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
        private void ExecuteShowLedige(object parameter)
        {
            var ledigeRacks = _rackService.GetRacksByStatus(RackStatus.Available);
            UpdateDisplayedRacks(ledigeRacks);
        }
        private void ExecuteShowOptaget(object parameter)
        {
            var optagetRacks = _rackService.GetRacksByStatus(RackStatus.Occupied);
            UpdateDisplayedRacks(optagetRacks);
        }

        private void ExecuteShowAndet(object parameter)
        {
            var andetRacks = _rackService.GetRacksByStatus(RackStatus.Other);
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