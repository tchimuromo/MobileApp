using HostcareInsuranceBrokers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostCareInsurance.Models
{
    public class QuatationResponseModel
    {
        public virtual string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public double Value { get; set; }
        public string Premium { get; set; }
        public virtual string VehicleUse { get; set; }
        public virtual string Mileage { get; set; }
        public virtual string Courtesy { get; set; }
        public virtual string ParkAddress { get; set; }
        public virtual string Color { get; set; }
        public virtual string Cover { get; set; }
        public virtual double PremiumRate { get; set; }
        public virtual string Owner { get; set; }
    }
}
