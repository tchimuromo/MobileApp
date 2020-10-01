using MobileApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel model;

        public LoginPage(LoginViewModel model)
        {
            InitializeComponent();
            BindingContext = this.model = model;
        }
        public LoginPage()
        {
            BindingContext = new LoginViewModel();
        }
    }
}