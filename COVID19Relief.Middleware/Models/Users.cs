using System;
namespace COVID19Relief.Middleware.Models
{
    public class Users
    {
        public Users()
        {

        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string bvn { get; set; }
        public string BvnIsValidated { get; set; }
        public string Email { get; set; }
        public string EmailIsvalidated { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberIsValidated { get; set; }
        public string AccountNumber { get; set; }
        public string AccountNumberIsValidated { get; set; }
        public int BankId { get; set; }
        public int StateId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }


    }
}
