using System;
using System.Collections.Generic;
using System.Text;

namespace HostCareInsurance.Models
{
    public class HomeInsuranceModel
    {
        public Guid ID { get; set; }
        public string TypeOfConstruction { get; set; }
        public string Address { get; set; }
        public double PropertyValue { get; set; }
        public virtual string Owner { get; set; }
        public virtual string Premium { get; set; }
    }
}
