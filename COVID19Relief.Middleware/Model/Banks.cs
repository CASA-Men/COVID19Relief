using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class Banks
    {
        public byte BankId { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public string BankSortCode { get; set; }
        public string BankType { get; set; }
        public string Nipcode { get; set; }
    }
}
