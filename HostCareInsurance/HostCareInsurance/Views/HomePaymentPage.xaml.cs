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
    public partial class HomePaymentPage : ContentPage
    {
        private readonly PaymentViewModel paymentViewModel;
        public HomePaymentPage(PaymentViewModel paymentViewModel)
        {
            InitializeComponent();
            BindingContext = this.paymentViewModel = paymentViewModel;

        }
    }
}