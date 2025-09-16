using MiddelbyReolsystemMVVM.Helpers.Commands;
using MiddelbyReolsystemMVVM.Helpers;
using System;
using System.Windows.Input;
using MiddelbyReolsystemMVVM.Services;
using System.Collections.ObjectModel;
using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.ViewModels;

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

            InitializaCommands();
            
        }
        /*
        {
            _ws = ws ?? throw new ArgumentNullException(nameof(ws));
            GoAdminRenter = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRenterView>());
            GoAdminRack = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRackView>());
        }
        */
        private void InitializaCommands()
        {
            ShowLedigeCommand = new RelayCommand(ExecuteShowLedige);
            ShowOptagetCommand = new RelayCommand(ExecuteShowOptaget);
            ShowAndetCommand = new RelayCommand(ExecuteShowAndet);
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