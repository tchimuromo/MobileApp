using HostcareInsuranceBrokers.Models;
using System;

namespace HostCareInsurance.Models.ViewModels
{
    public class VehicleInsuranceModel
    {
        public VehicleInsuranceModel()
        {
        }

        public Guid ID { get; set; }
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
        public virtual byte[] PhotoPath1 { get; set; }
        public virtual byte[] PhotoPath2 { get; set; }
        public virtual byte[] PhotoPath3 { get; set; }
        public virtual byte[] PhotoPath4 { get; set; }
        public virtual string Owner { get; set; }

    }
}