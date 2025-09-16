using MiddelbyReolsystemMVVM.Helpers;
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
    }
}
