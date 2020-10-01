using HostCareInsurance.Views;
using MobileApp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HostCareInsurance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage(new Models.ViewModels.HomeViewModel()));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
