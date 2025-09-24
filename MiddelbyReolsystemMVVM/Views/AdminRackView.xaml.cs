using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Viewmodels;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Views
{
    public partial class AdminRackView : Window
    {
        public AdminRackView()
        {
            InitializeComponent();
            DataContext = new AdminRackViewModel();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
