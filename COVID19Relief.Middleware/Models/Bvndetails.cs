using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Models
{
    public partial class Bvndetails
    {
        public int BvndetailsId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string EnrollmentBank { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string LgaofOrigin { get; set; }
        public string LgaofResidence { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumberAlt { get; set; }
        public string ResidentialAddress { get; set; }
        public string StateOfOrigin { get; set; }
        public string StateOfResidence { get; set; }
        public string WatchListed { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Users User { get; set; }
    }
}
