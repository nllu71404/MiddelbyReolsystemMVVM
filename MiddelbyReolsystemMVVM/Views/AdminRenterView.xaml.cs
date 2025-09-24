
using MiddelbyReolsystemMVVM.Viewmodels;
using System.Windows;

namespace MiddelbyReolsystemMVVM.Views
{
    public partial class AdminRenterView : Window
    {
        
        private AdminRenterViewModel viewModel;
        public AdminRenterView()
        {
            InitializeComponent();
            // MVVM: bind til ViewModel (som bruger WindowService til navigation)
            viewModel = new AdminRenterViewModel();
            DataContext = viewModel;
        }

        // Bevar state: skjul i stedet for at lukke vinduet
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void OpenRackOverview_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OpenRackOverview();
        }

        private void OpenAdminRackView_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OpenAdminRackView();
        }

        private void New_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ClearInputs();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedRenter != null)
            {
                viewModel.LoadFromSelected();
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SelectedRenter != null)
            {
                viewModel.DeleteSelected();
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.SaveNew();
        }
    }
}
