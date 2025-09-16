using MiddelbyReolsystemMVVM.Helpers.Commands;
using MiddelbyReolsystemMVVM.Helpers;
using System;
using System.Windows.Input;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class RackViewModel
    {
        private readonly IWindowService _ws;
        public ICommand GoAdminRenter { get; }
        public ICommand GoAdminRack { get; }

        public RackViewModel(IWindowService ws)
        {
            _ws = ws ?? throw new ArgumentNullException(nameof(ws));
            GoAdminRenter = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRenterView>());
            GoAdminRack = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRackView>());
        }
    }
}