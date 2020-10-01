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
    public partial class PaymentPage : ContentPage
    {
        private readonly PaymentViewModel viewModel;

        public PaymentPage(PaymentViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            //viewModel.PaymentCommmand.Execute(null);
        }
    }
}