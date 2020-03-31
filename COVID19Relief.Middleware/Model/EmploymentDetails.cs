using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class EmploymentDetails
    {
        public int EmploymentDetailsId { get; set; }
        public int UsersId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAddress { get; set; }
        public string OrganizationType { get; set; }
        public string PositionHeld { get; set; }
        public string EmploymentType { get; set; }
        public string EmploymentStatus { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime LastDayAtJob { get; set; }
        public int Stateid { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Users Users { get; set; }
    }
}
