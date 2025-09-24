using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Helpers.Commands;
using System;
using System.Windows.Input;
using MiddelbyReolsystemMVVM.Views;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class MainViewModel
    {
        public ICommand OpenRackCommand { get; }
        public ICommand OpenRenterCommand { get; }
        public ICommand OpenAdminRackCommand { get; }

        // Kommandoerne nedenunder skal åbne de respektive vinduer, og det skal de kende IWindowService for at kunne
        // Singleton betyder at der kun kan åbnes et vindue af den type ad gangen
        public MainViewModel()
        {
            OpenRackCommand = new RelayCommand(_ => (new RackOverview()).Show());
            OpenRenterCommand = new RelayCommand(_ => (new AdminRenterView()).Show());
            OpenAdminRackCommand = new RelayCommand(_ => (new AdminRackView()).Show());
        }
    }
}

