using HostCareInsurance.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HostCareInsurance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel model;

        public HomePage(HomeViewModel model)
        {
            InitializeComponent();
            BindingContext = this.model = model;
        }
    }
}