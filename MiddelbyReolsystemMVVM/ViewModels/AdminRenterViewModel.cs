using MiddelbyReolsystemMVVM.Models;
using MiddelbyReolsystemMVVM.ViewModels;       
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MiddelbyReolsystemMVVM.Views;
using MiddelbyReolsystemMVVM.Repositories;

namespace MiddelbyReolsystemMVVM.Viewmodels
{
    public class AdminRenterViewModel : BaseViewModel
    {

        public IFileRenterRepository _fileRenterRepository;

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
        public ObservableCollection<Renter> Renters { get; } = new ObservableCollection<Renter>();
        public Renter? SelectedRenter { get; set; } 


        // Constructors - som både kender til WindowService og RenterService
        public AdminRenterViewModel(IFileRenterRepository fileRenterRepository)
        {
           _fileRenterRepository = fileRenterRepository;
            // Fyld Renters med data fra repository
            foreach (var renter in _fileRenterRepository.GetAll())
            {
                Renters.Add(renter);
            }

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

        public void AddRenter(Renter newRenter)
        {
            Renters.Add(newRenter);
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
            message = "Reollejer gemt korrekt!";
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

           //_fileRenterRepository.AddRenter(newRenter); -- Dobbeltkonfekt 
            Renters.Add(newRenter);
            _fileRenterRepository.SaveAll(Renters.ToList());// vis i UI
            SelectedRenter = newRenter;
            OnPropertyChanged(nameof(SelectedRenter));
        }

        // ---------- Simple Edit/Delete så bindings ikke fejler ---------- FIND UD AF HVORDAN MAN KAN OVERSKRIVE DET ÆLDRE REOLLEJER-OBJEKT
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
            _fileRenterRepository.DeleteRenter(SelectedRenter);
            Renters.Remove(SelectedRenter);
            SelectedRenter = Renters.FirstOrDefault();
            OnPropertyChanged(nameof(SelectedRenter));
        }
    }
}