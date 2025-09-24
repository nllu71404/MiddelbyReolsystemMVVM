
using MiddelbyReolsystemMVVM.Viewmodels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiddelbyReolsystemMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        

        private void OpenRackOverview_Button_Click(object sender, RoutedEventArgs e)
        {
            new MainViewModel().OpenRackOverview();
        }

        private void OpenAdminRenterView_Button_Click(object sender, RoutedEventArgs e)
        {
            new MainViewModel().OpenAdminRenterView();
        }

        private void OpenAdminRackView_Button_Click(object sender, RoutedEventArgs e)
        {
            new MainViewModel().OpenAdminRackView();
        }
    }
}