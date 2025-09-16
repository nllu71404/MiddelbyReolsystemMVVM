using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Helpers.Commands;
using System;
using System.Windows.Input;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class MainViewModel
    {
        private readonly IWindowService _ws;

        public ICommand OpenRackCommand { get; }
        public ICommand OpenRenterCommand { get; }
        public ICommand OpenAdminRackCommand { get; }

        // Kun denne ctor – vi sætter DataContext i code-behind og giver WindowService herfra
        public MainViewModel(IWindowService ws)
        {
            _ws = ws ?? throw new ArgumentNullException(nameof(ws));

            OpenRackCommand = new RelayCommand(_ => _ws.ShowSingleton<Views.RackOverview>());
            OpenRenterCommand = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRenterView>());
            OpenAdminRackCommand = new RelayCommand(_ => _ws.ShowSingleton<Views.AdminRackView>());
        }
    }
}

