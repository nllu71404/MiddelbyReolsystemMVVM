using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.Services;
using MiddelbyReolsystemMVVM.ViewModels;       
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MiddelbyReolsystemMVVM.Views;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class AdminRenterViewModel : BaseViewModel
    {
        private readonly IRenterService _renterService;

        // Inputs til TextBoxes (Som skal være TwoWay)
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string BankInformation { get; set; } = "";
        public bool ConsentGiven { get; set; } = false;

        // Fejlbesked nederst i viewet
        public string ErrorMessage { get; private set; } = "";

        // Data til UI
        public ObservableCollection<Renter> Renters { get; }
        public Renter? SelectedRenter { get; set; }

        // Constructors - som både kender til WindowService og RenterService
        public AdminRenterViewModel() : this(RenterService.Instance()) { }

        public AdminRenterViewModel(IRenterService renterService)
        {
            _renterService = renterService;

            Renters = new ObservableCollection<Renter>(_renterService.GetAllRenters());
            SelectedRenter = Renters.FirstOrDefault();
        }
        // Navigation
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


        // ---------- Workflow ----------

        public void ClearInputs()
        {
            FirstName = LastName = Email = PhoneNumber = BankInformation = "";
            ConsentGiven = false;

            // ryd evt. gammel fejl
            ErrorMessage = "";
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(BankInformation));
            OnPropertyChanged(nameof(ConsentGiven));
            OnPropertyChanged(nameof(ErrorMessage));
        }

        public bool ValidateInputs(out string message)
        {
            if (string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(PhoneNumber) ||
                string.IsNullOrWhiteSpace(BankInformation))
            {
                message = "FEJL: Udfyld alle felter før du gemmer!";
                return false;
            }
            if (!ConsentGiven)
            {
                message = "FEJL: Du skal afkrydse samtykkeerklæringen!";
                return false;
            }
            message = "";
            return true;
        }

        public void SaveNew()
        {
            // nulstil fejl
            ErrorMessage = "";
            OnPropertyChanged(nameof(ErrorMessage));

            if (!ValidateInputs(out var msg))
            {
                ErrorMessage = msg;
                OnPropertyChanged(nameof(ErrorMessage));
                return;
            }

            var newRenter = new Renter(
                FirstName,
                LastName,
                Email,
                PhoneNumber,
                BankInformation,
                ConsentGiven
            );

            _renterService.AddRenter(newRenter); // gem i service/repo
            Renters.Add(newRenter);              // vis i UI
            SelectedRenter = newRenter;
            OnPropertyChanged(nameof(SelectedRenter));
        }

        // ---------- Simple Edit/Delete så bindings ikke fejler ----------
        public void LoadFromSelected()
        {
            if (SelectedRenter == null) return;
            FirstName = SelectedRenter.FirstName;
            LastName = SelectedRenter.LastName;
            Email = SelectedRenter.Email;
            PhoneNumber = SelectedRenter.PhoneNumber;
            BankInformation = SelectedRenter.BankInformation;
            ConsentGiven = SelectedRenter.ConsentGiven;

            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(PhoneNumber));
            OnPropertyChanged(nameof(BankInformation));
            OnPropertyChanged(nameof(ConsentGiven));
        }

        public void DeleteSelected()
        {
            if (SelectedRenter == null) return;

            var id = SelectedRenter.Id;              
            _renterService.DeleteRenter(id);         
            Renters.Remove(SelectedRenter);          
            SelectedRenter = Renters.FirstOrDefault();
            OnPropertyChanged(nameof(SelectedRenter));
        }
    }
}