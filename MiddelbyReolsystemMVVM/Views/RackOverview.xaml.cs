using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Viewmodels;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Views
{
    public partial class RackOverview : Window
    {
        public RackOverview()
        {
            InitializeComponent();
            DataContext = new RackViewModel(new WindowService());
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        { e.Cancel = true; this.Hide(); }
    }
}
