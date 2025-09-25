using MiddelbyReolsystemMVVM.Views;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class MainViewModel
    {
        public void OpenRackOverview()
        {
            var rackOverview = new RackOverview();
            rackOverview.Show();
        }

        public void OpenAdminRenterView()
        {
            var adminRenterView = new AdminRenterView();
            adminRenterView.Show();
        }

        public void OpenAdminRackView()
        {
            var adminRackView = new AdminRackView();
            adminRackView.Show();
        }
    }
}

