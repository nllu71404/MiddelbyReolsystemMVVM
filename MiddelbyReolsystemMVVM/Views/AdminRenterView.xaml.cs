using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Viewmodels;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Views
{
    public partial class AdminRenterView : Window
    {
        public AdminRenterView()
        {
            InitializeComponent();
            // MVVM: bind til ViewModel (som bruger WindowService til navigation)
            DataContext = new AdminRenterViewModel();
        }

        // Bevar state: skjul i stedet for at lukke vinduet
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
