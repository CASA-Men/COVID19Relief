using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class Users
    {
        public Users()
        {
            Bvndetails = new HashSet<Bvndetails>();
            PaymentDetails = new HashSet<PaymentDetails>();
            SalaryDetails = new HashSet<SalaryDetails>();
            SalaryWorkersDetails = new HashSet<SalaryWorkersDetails>();
            SelfEmployedWorkersDetails = new HashSet<SelfEmployedWorkersDetails>();
        }

        public int UsersId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Bvn { get; set; }
        public bool? BvnIsValidated { get; set; }
        public string Email { get; set; }
        public bool? EmailIsValidated { get; set; }
        public string PhoneNumber { get; set; }
        public bool? PhoneNumberIsValidated { get; set; }
        public string AccountNumber { get; set; }
        public bool? AccountNumberIsValidated { get; set; }
        public string BankId { get; set; }
        public string StateId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string IdentityDocumentType { get; set; }
        public string DocumentIdNumber { get; set; }
        public int? SpouseUniqueNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string MaritalStatus { get; set; }
        public int? NoOfDependents { get; set; }
        public int? LocalGovernmentId { get; set; }

        public virtual ICollection<Bvndetails> Bvndetails { get; set; }
        public virtual ICollection<PaymentDetails> PaymentDetails { get; set; }
        public virtual ICollection<SalaryDetails> SalaryDetails { get; set; }
        public virtual ICollection<SalaryWorkersDetails> SalaryWorkersDetails { get; set; }
        public virtual ICollection<SelfEmployedWorkersDetails> SelfEmployedWorkersDetails { get; set; }
    }
}
