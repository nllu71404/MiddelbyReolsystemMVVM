using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddelbyReolsystemMVVM.Models
{
    public class Renter
    {
        private static int _nexdtId = 1;
        public int Id { get; private set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string BankInformation { get; set; } = "";
        public bool ConsentGiven { get; set; }

        
        public Renter(string firstName, string lastName, string email, string phoneNumber, string bankInformation, bool consentGiven)
        {
            Id = _nexdtId++;            // Her sættes id til nextId og derefter incrementeres nextId med 1
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            BankInformation = bankInformation;
            ConsentGiven = consentGiven;
        }

        public override string ToString() => $"{FirstName} {LastName}";

        
    }
}
