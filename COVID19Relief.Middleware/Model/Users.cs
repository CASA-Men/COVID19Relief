using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class Users
    {
        public Users()
        {
            EmploymentDetails = new HashSet<EmploymentDetails>();
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

        public virtual ICollection<EmploymentDetails> EmploymentDetails { get; set; }
    }
}
