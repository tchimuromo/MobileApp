using MobileApp.ViewModels;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private readonly RegisterViewModel model;

        public RegisterPage(RegisterViewModel model)
        {
            InitializeComponent();
            BindingContext = this.model = model;
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //  await  Navigation.PushAsync(new LoginPage());
        //}
    }
}