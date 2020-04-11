using System;
using System.Collections.Generic;

namespace COVID19Relief.Middleware.Model
{
    public partial class StateLocalGovernment
    {
        public short StateLocalGovernmentId { get; set; }
        public byte StateId { get; set; }
        public string LocalGovernmentName { get; set; }
        public byte IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
