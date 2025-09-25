using MiddelbyReolsystemMVVM.Services;
using MiddelbyReolsystemMVVM.Viewmodels;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Views
{
    public partial class RackOverview : Window
    {
        
        private RackService _rackService;
        private RackViewModel viewModel;
        public RackOverview()
        {
            InitializeComponent();
            _rackService = new RackService();
            viewModel = new RackViewModel(_rackService);
            DataContext = viewModel;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        { e.Cancel = true; this.Hide(); }

        private void OpenAdminRenterViewButton_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(_rackService).OpenAdminRenterView();
        }

        private void OpenAdminRenterView_Button_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(_rackService).OpenAdminRenterView();
        }

        private void OpenAdminRackView_Button_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(_rackService).OpenAdminRackView();
        }

        private void ShowAvailable_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ExecuteShowLedige(sender);
        }

        private void ShowOccupied_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ExecuteShowOptaget(sender);
        }

        private void ShowOther_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ExecuteShowAndet(sender);
        }
    }
}
