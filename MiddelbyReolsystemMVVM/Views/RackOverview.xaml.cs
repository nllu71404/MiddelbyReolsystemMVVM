using MiddelbyReolsystemMVVM.Repositories;
using MiddelbyReolsystemMVVM.Services;
using MiddelbyReolsystemMVVM.Viewmodels;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Views
{
    public partial class RackOverview : Window
    {
        
        private RackService _rackService;
        private RackViewModel viewModel;
        private IFileRackRepository fileRackRepository;
        public RackOverview()
        {
            InitializeComponent();
            _rackService = new RackService();
            fileRackRepository = new FileRackRepository("racks.json", _rackService);
            viewModel = new RackViewModel(fileRackRepository);
            DataContext = viewModel;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        { e.Cancel = true; this.Hide(); }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RackViewModel viewModel = (RackViewModel)DataContext;
            viewModel.ExecuteShowLedige(sender);
        }

        private void OpenAdminRenterViewButton_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(fileRackRepository).OpenAdminRenterView();
        }

        private void OpenAdminRenterView_Button_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(fileRackRepository).OpenAdminRenterView();
        }

        private void OpenAdminRackView_Button_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(fileRackRepository).OpenAdminRackView();
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

        private void AssignRenter_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AssignRenterToSelectedRack();
        }

        private void RemoveRenter_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveRenterFromSelectedRack();
        }
    }
}
