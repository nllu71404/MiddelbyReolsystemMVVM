using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Helpers.Commands;
using System;
using System.Windows.Input;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class AdminRackViewModel
    {
        private readonly IWindowService _ws;
        public ICommand GoRackOverview { get; }
        public ICommand GoAdminRenter { get; }

        public AdminRackViewModel(IWindowService ws)
        {
            _ws = ws ?? throw new ArgumentNullException(nameof(ws));
            GoRackOverview = new RelayCommand(_ => _ws.ShowSingleton<Views.RackOverview>());
            GoAdminRenter = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRenterView>());
        }
    }
}