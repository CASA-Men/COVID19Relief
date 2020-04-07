using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class PaymentDetails
    {
        public int PaymentDetailsId { get; set; }
        public int UserId { get; set; }
        public string PaymentRef { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Users User { get; set; }
    }
}
