using System.Windows;
using System.Windows.Controls;
using MiddelbyReolsystemMVVM.Services;
using MiddelbyReolsystemMVVM.Viewmodels;

namespace MiddelbyReolsystemMVVM.Views
{
    public partial class RackOverviewPage : Page
    {
        private INavigationService? _nav;

        public RackOverviewPage()
        {
            InitializeComponent();
            Loaded += OnLoaded; 
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_nav != null) return; // kør kun én gang

            _nav = new PageNavigationService(this.NavigationService);
            //_nav.Register("AdminRenterPage", () => new AdminRenterPage());
            //_nav.Register("AdminRackPage", () => new AdminRackPage());

            // DataContext = new RackViewModel(new RackService(), _nav);
        }
    }
}
