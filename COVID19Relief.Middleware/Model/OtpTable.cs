using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class OtpTable
    {
        public int OtpTableId { get; set; }
        public string UserEmail { get; set; }
        public string Code { get; set; }
        public DateTime DateInserted { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateOtpverified { get; set; }
    }
}
