using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class SalaryWorkersDetails
    {
        public int SalaryWorkersDetaildId { get; set; }
        public int UserId { get; set; }
        public string ActiveEmail { get; set; }
        public string ActivePhoneNumber { get; set; }
        public bool AreYouCurrentlyInEmployment { get; set; }
        public string EmployerName { get; set; }
        public string EmployerIndustry { get; set; }
        public string EmployerRcNoOrBrNo { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public string AvgMonthlySalaryForSixMonths { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Users User { get; set; }
    }
}
