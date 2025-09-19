using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Helpers.Commands;
using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class AdminRenterViewModel
    {
        private readonly IWindowService _ws;
        private readonly IRenterService _renterService;

        // Navigation til at gå mellem knapper
        public ICommand GoRackOverview { get; }
        public ICommand GoAdminRack { get; }

        // Data til UI
        public ObservableCollection<Renter> Renters { get; }
        public Renter? SelectedRenter { get; set; }

        // Konstruktør
        public AdminRenterViewModel(IWindowService ws) : this(ws, new RenterService()) { }

        public AdminRenterViewModel(IWindowService ws, IRenterService renterService)
        {
            _ws = ws ?? throw new ArgumentNullException(nameof(ws));
            _renterService = renterService ?? throw new ArgumentNullException(nameof(renterService));

            // Navigation til at gå mellem knapper
            GoRackOverview = new RelayCommand(_ => _ws.ShowSingleton<Views.RackOverview>());
            GoAdminRack = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRackView>());

            // Renterdate
            Renters = new ObservableCollection<Renter>(_renterService.GetAllRenters());
            SelectedRenter = Renters.FirstOrDefault();
        }
    }
}
