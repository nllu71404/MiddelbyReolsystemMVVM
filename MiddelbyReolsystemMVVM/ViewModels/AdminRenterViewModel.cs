using MiddelbyReolsystemMVVM.Helpers;
using MiddelbyReolsystemMVVM.Helpers.Commands;
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

        // Navigation mellem knapper
        public ICommand GoRackOverview { get; }
        public ICommand GoAdminRack { get; }

        // Kommandoer
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

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
        public AdminRenterViewModel() : this(new RenterService()) { }

        public AdminRenterViewModel(IRenterService renterService)
        {
            _renterService = renterService ?? throw new ArgumentNullException(nameof(renterService));

            GoRackOverview = new RelayCommand(_ => (new RackOverview()).Show());
            GoAdminRack = new RelayCommand(_ => (new AdminRackView()).Show());

            Renters = new ObservableCollection<Renter>(_renterService.GetAllRenters());
            SelectedRenter = Renters.FirstOrDefault();

            // Opret/Gem
            NewCommand = new RelayCommand(_ => ClearInputs());
            SaveCommand = new RelayCommand(_ => SaveNew());

            EditCommand = new RelayCommand(_ => LoadFromSelected(), _ => SelectedRenter != null);
            DeleteCommand = new RelayCommand(_ => DeleteSelected(), _ => SelectedRenter != null);
        }

        // ---------- Workflow ----------
        private void ClearInputs()
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

        private bool ValidateInputs(out string message)
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

        private void SaveNew()
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
        private void LoadFromSelected()
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

        private void DeleteSelected()
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