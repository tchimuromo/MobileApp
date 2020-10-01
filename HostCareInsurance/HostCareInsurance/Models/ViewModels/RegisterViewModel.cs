using HostCareInsurance.Models;
using HostCareInsurance.Models.ViewModels;
using HostCareInsurance.Views;
using HostcareInsuranceBrokers.Models;
using MobileApp.Models;
using MobileApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class RegisterViewModel:INotifyPropertyChanged
    {
      // ApiServices apiServices = new ApiServices();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private string fullName;
        public virtual string FullName { get { return fullName; } set { fullName = value; OnPropertyChanged(); } }
        private DateTime dateOfBirth;
        public virtual DateTime DateOfBirth { get => dateOfBirth; set { dateOfBirth = value; OnPropertyChanged(); } }
       
        private string address;
        public virtual string Address { get { return address; } set { address = value; OnPropertyChanged(); } }
        private string employmentDetails;
        
        private string nationalID;
        public virtual string NationalID { get { return nationalID; } set { nationalID = value; OnPropertyChanged(); } }

        // [Remote(action: "IsEmailInUse", controller: "Account")]
        private string email;
        public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }
        private string password;
        public string Password { get { return password; } set { password = value; OnPropertyChanged(); } }

        private string confirmPassword;
        public string ConfirmPassword { get { return confirmPassword; } set { confirmPassword = value; OnPropertyChanged(); } }
        private string covertype;
        public virtual string Covertype { get { return covertype; } set { covertype = value; OnPropertyChanged(); } }
        private string phonenumber;
        public virtual string PhoneNumber { get { return phonenumber; } set { phonenumber = value; OnPropertyChanged(); } }
        private string userName;
        public virtual string UserName { get { return userName; } set { userName = value; OnPropertyChanged(); } }
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        //public string Message { get; set; }
        public ICommand RegisterCommand { get; set; }
        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await Register());
        }


            public async Task Register()
        {
            IsBusy = true;

            RegisterUserBindingModel model = new RegisterUserBindingModel
            {
              
                NationalID = NationalID,
                DateOfBirth = DateOfBirth,
                Address = Address,
                Covertype = "VehicleCover",
                Email = Email,
               
                FullName = FullName,
                PhoneNumber = PhoneNumber,
                Password = "Pass123#",
                ConfirmPassword = "Pass123#",
                UserName = UserName

            };

            var json = JsonConvert.SerializeObject(model);
            var response = await Task.Run(()=>HttpServices.Post("Account/Register", json, ""));
            var result = JsonConvert.DeserializeObject<RegisterSuccess>(response);
            if (result.status == "Success")
            {
                HostCareInsurance.Configs.Config.Username = Email;
                if(HostCareInsurance.Configs.Config.CoverType== HostcareInsuranceBrokers.Models.Covertype.VehicleInsurance)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new VehicleQuotationPage(new VehicleQuotationViewModel()));
                }
                else if (HostCareInsurance.Configs.Config.CoverType == HostcareInsuranceBrokers.Models.Covertype.HomeInsurance)
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new HomeQuotationPage(new HomeQuotationViewModel()));
                }
               
                IsBusy = false;
            }
            //return result;
            IsBusy = false;

        }

    }
}
