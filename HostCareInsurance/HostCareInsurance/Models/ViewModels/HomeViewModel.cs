using MobileApp;
using MobileApp.Models.ViewModels;
using MobileApp.ViewModels;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HostCareInsurance.Models.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string iPAddress;
        public string IPAddress
        {
            get { return iPAddress; }
            set
            {
                iPAddress = value;
                OnPropertyChanged();
                Configs.Config.IPAddress = value;
            } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Command HomeInsuranceQuote { get; set; }
        public Command VehicleQuote { get; set; }
        public Command Account { get; set; }

        public HomeViewModel()
        {
            VehicleQuote = new Command(async() => await GetVehicleQuote());
            Account = new Command(async() => await GetAccount());
            HomeInsuranceQuote = new Command(async () => await GetHomeInsuranceQuote());

        }
        private async Task GetHomeInsuranceQuote()
        {
            Configs.Config.CoverType = HostcareInsuranceBrokers.Models.Covertype.HomeInsurance;
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage(new RegisterViewModel()), true);
        }
        private async Task GetVehicleQuote()
        {
            Configs.Config.CoverType = HostcareInsuranceBrokers.Models.Covertype.VehicleInsurance;
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage(new RegisterViewModel()), true);
        }
        private async Task GetAccount()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage(new LoginViewModel()), true);
        }
    }
}
