using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Helpers.Commands;
using System;
using System.Windows.Input;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class AdminRenterViewModel
    {
        private readonly IWindowService _ws;
        public ICommand GoRackOverview { get; }
        public ICommand GoAdminRack { get; }

        public AdminRenterViewModel(IWindowService ws)
        {
            _ws = ws ?? throw new ArgumentNullException(nameof(ws));
            GoRackOverview = new RelayCommand(_ => _ws.ShowSingleton<Views.RackOverview>());
            GoAdminRack = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRackView>());
        }
    }
}
