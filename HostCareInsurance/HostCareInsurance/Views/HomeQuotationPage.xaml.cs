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
    public partial class HomeQuotationPage : ContentPage
    {
        private readonly HomeQuotationViewModel model;

        public HomeQuotationPage(HomeQuotationViewModel model)
        {
            InitializeComponent();
            BindingContext = this.model = model;
        }
    }
}