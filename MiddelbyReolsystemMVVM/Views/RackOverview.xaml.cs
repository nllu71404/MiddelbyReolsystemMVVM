using MiddelbyReolsystemMVVM.Services;
using MiddelbyReolsystemMVVM.Viewmodels;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Views
{
    public partial class RackOverview : Window
    {
        public RackOverview()
        {
            InitializeComponent();
            DataContext = new RackViewModel(new RackService());
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        { e.Cancel = true; this.Hide(); }

        private void OpenAdminRenterViewButton_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(new RackService()).OpenAdminRenterView();
        }

        private void OpenAdminRenterView_Button_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(new RackService()).OpenAdminRenterView();
        }

        private void OpenAdminRackView_Button_Click(object sender, RoutedEventArgs e)
        {
            new RackViewModel(new RackService()).OpenAdminRackView();
        }
    }
}
