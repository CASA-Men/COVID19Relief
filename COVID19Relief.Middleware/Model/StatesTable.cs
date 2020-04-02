using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class StatesTable
    {
        public byte StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
