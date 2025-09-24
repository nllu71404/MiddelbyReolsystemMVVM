using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Helpers.Commands;
using System;
using System.Windows.Input;
using MiddelbyReolsystemMVVM.Views;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class AdminRackViewModel
    {
        public ICommand GoRackOverview { get; }
        public ICommand GoAdminRenter { get; }

        public AdminRackViewModel()
        {
            GoRackOverview = new RelayCommand(_ => (new RackOverview()).Show());
            GoAdminRenter = new RelayCommand(_ => (new AdminRenterView()).Show());
        }
    }
}