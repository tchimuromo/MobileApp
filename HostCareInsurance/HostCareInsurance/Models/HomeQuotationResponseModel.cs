using System;
using System.Collections.Generic;
using System.Text;

namespace HostCareInsurance.Models
{
    public class HomeQuotationResponseModel
    {
        public string TypeOfConstruction { get; set; }
        public string Address { get; set; }
        public double PropertyValue { get; set; }
        public virtual string Owner { get; set; }

        public string PremiumType { get; set; }
        public  double InsuredAmount { get; set; }
    }
}
