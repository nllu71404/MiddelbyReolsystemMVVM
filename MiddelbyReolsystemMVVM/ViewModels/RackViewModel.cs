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
            var ledigeRacks = _rackService.GetRacksByStatus(RackStatus.Other);
            UpdateDisplayedRacks(ledigeRacks);
        }
        private void ExecuteShowOptaget(object parameter)
        {
            var optagetRacks = _rackService.GetRacksByStatus(RackStatus.Occupied);
            UpdateDisplayedRacks(optagetRacks);
        }

        private void ExecuteShowAndet(object parameter)
        {
            //System.Diagnostics.Debug.WriteLine("ExecuteShowLedige kaldt!");
            var andetRacks = _rackService.GetRacksByStatus(RackStatus.Available);
            //System.Diagnostics.Debug.WriteLine($"Fandt {ledigeRacks.Count()} ledige reoler");
            UpdateDisplayedRacks(andetRacks);
        }
        
        private void UpdateDisplayedRacks(IEnumerable<Rack> racks)
        {
            //System.Diagnostics.Debug.WriteLine($"UpdateDisplayedRacks kaldt med {racks.Count()} reoler");
            var rackList = racks.ToList();
            DisplayedRacks = new ObservableCollection<Rack>(rackList);

            //System.Diagnostics.Debug.WriteLine($"DisplayedRacks har nu {DisplayedRacks.Count} elementer");

            OnPropertyChanged(nameof(DisplayedRacks));
            /*
            foreach (var rack in rackList)
            {
                DisplayedRacks.Add(rack);
            }

            try
            {
                foreach (var rack in racks)
                {
                    System.Diagnostics.Debug.WriteLine($"Forsøger at tilføje reol: {rack.RackNumber}");
                    DisplayedRacks.Add(rack);
                    System.Diagnostics.Debug.WriteLine($"Tilføjet reol: {rack.RackNumber}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"FEJL i UpdateDisplayedRacks: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            */

            
        }
    }
}