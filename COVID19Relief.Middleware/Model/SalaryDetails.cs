using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class SalaryDetails
    {
        public int SalaryDetailsId { get; set; }
        public int UserId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public double SalaryAmount { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Users User { get; set; }
    }
}
