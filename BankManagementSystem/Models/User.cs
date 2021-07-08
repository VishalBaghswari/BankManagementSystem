using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class User
    {
        public string UserId { get; set; }
        public long UserAccountNo { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GuardianType { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public string Citizenship { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }
        public long Contact { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AccountType { get; set; }
        public string BranchName { get; set; }
        public string CitizenshipStatus { get; set; }
        public long InitialDepositeAmount { get; set; }

        public string PanCard { get; set; }
        public string RefAccountHolderName { get; set; }
        public long RefAccountNo { get; set; }
        public string RefAccountHolderAddress { get; set; }



    }
}
