using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class SelfEmployedWorkersDetails
    {
        public int SelfEmployedWorkersDetailsId { get; set; }
        public int UserId { get; set; }
        public string ActiveResidentialAddress { get; set; }
        public string ActivePhoneNumber { get; set; }
        public string NameOfBusiness { get; set; }
        public string Industry { get; set; }
        public string BusinessDescription { get; set; }
        public string BusinessRcNoOrBrNo { get; set; }
        public bool OwnBusinessAlone { get; set; }
        public bool BusinessStillOperational { get; set; }
        public DateTime StartDateOfBusiness { get; set; }
        public DateTime CloseDateOfBusiness { get; set; }
        public DateTime DateOfLeaving { get; set; }
        public string AvgMonthlySalaryForSixMonths { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Users User { get; set; }
    }
}
