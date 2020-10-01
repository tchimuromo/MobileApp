using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuaranceApp.Modals
{

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class RegisterModel
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string EmploymentDetails { get; set; }
        public string NationalID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Covertype { get; set; }
        public string PhoneNumber { get; set; }
    }
    public enum Covertype
    {
        None,
        HomeCover,
        VehicleCover

    }


    public class VehicleInsuranceModel
    {
        public string ID { get; set; }
        public string RegistrationNumber { get; set; }
        public int Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Value { get; set; }
        public int Premium { get; set; }
        public string VehicleUse { get; set; }
        public string Mileage { get; set; }
        public string Courtesy { get; set; }
        public string ParkAddress { get; set; }
        public string Color { get; set; }
        public string Cover { get; set; }
        public string PhotoPath1 { get; set; }
        public string PhotoPath2 { get; set; }
        public string PhotoPath3 { get; set; }
        public string PhotoPath4 { get; set; }
        public string Owner { get; set; }
    }


    public class LoginResponse
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public DateTime Expiration { get; set; }
    }


    public class QuatationResponseModel
    {
        public string registrationNumber { get; set; }
        public int make { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public float value { get; set; }
        public int premium { get; set; }
        public string vehicleUse { get; set; }
        public string mileage { get; set; }
        public string courtesy { get; set; }
        public string parkAddress { get; set; }
        public string color { get; set; }
        public string cover { get; set; }
        public float premiumRate { get; set; }
    }

    public class QuatationImage
    {
        public int Number { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
