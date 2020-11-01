using HostCareInsurance.Models;
using HostCareInsurance.Models.ViewModels;
using HostCareInsurance.Views;
using HostInsuranceAPI.Models.ViewModels;
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

namespace MobileApp.Models.ViewModels
{
    public class LoginViewModel:INotifyPropertyChanged
    {
        private ApiServices apiServices = new ApiServices();
        private bool isBusy;
        private bool isEnabled;
        private bool rememberMe;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }
         public bool RememberMe
        {
            get { return rememberMe; }
            set { rememberMe = value; OnPropertyChanged(); }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; OnPropertyChanged(); }
        }
        public string email = "tale@gmail.com";
        public string Email 
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }

        private string password = "Pass123#";

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }
        //  string message = "";
        public ICommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginAsync());
        }


        public async Task LoginAsync()
        {
            IsBusy = true;
            
                var model = new Login()
                {
                    Email = Email,
                    Password = Password

                };
                var json = JsonConvert.SerializeObject(model);

                var response = await Task.Run(() => HttpServices.Post("Account/Login", json, ""));

                var result = JsonConvert.DeserializeObject<TokenViewModel>(response);
                if (result.Token != null)
                {
                    HostCareInsurance.Configs.Config.Token = result.Token;
                    HostCareInsurance.Configs.Config.UserId = result.UserId;
                    HostCareInsurance.Configs.Config.Username = Email;
                    Device.BeginInvokeOnMainThread(async () => {
                        IsBusy = false;
                        await Application.Current.MainPage.Navigation.PushAsync(new DashboardPage());
                    });

                    IsBusy = false;


                }
                else
                {

                    // await DisplayAlert("Alert", "You have been alerted", "OK");
                    await Application.Current.MainPage.DisplayAlert("Login Failed", "Failed to login, Check your credentials", "Ok");
                IsBusy = false;
                
                }
            
            
           //IsBusy = false;
        }
        //{
        //    get
        //    {
        //        return new Command(async() => 
        //        {
        //            await apiServices.LoginAsync(Email, Password);
        //        });
        //    }


    }
}
