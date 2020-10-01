using HostcareInsuranceBrokers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class RegisterUserBindingModel
    {
        public virtual string UserName { get; set; }
        public virtual string FullName { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        public virtual string Address { get; set; }

       

        public virtual string NationalID { get; set; }

        // [Remote(action: "IsEmailInUse", controller: "Account")]
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public virtual string Covertype { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}
