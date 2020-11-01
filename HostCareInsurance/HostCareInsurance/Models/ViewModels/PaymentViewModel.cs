using HostCareInsurance.Views;
using InsuaranceApp.Modals;
using InsuaranceApp.ViewModel;
using MobileApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HostCareInsurance.Models.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        private readonly QuatationResponseModel quatation;

        public ObservableCollection<QuatationImage> Data = new ObservableCollection<QuatationImage>()
        {
            new QuatationImage{Number = 1, ImageUrl = "https://image.shutterstock.com/image-photo/mountains-during-sunset-beautiful-natural-600w-407021107.jpg"},
            new QuatationImage{Number = 2, ImageUrl = "history.png"},
            new QuatationImage{Number = 3, ImageUrl = "home.png"},
            new QuatationImage{Number = 4, ImageUrl = "user.png"}
        };

        public Command PaymentCommmand { get; set; }

        private QuatationResponseModel payment;

        public QuatationResponseModel Payment
        {
            get { return payment; }
            set { payment = value; OnPropertyChanged(); }
        }
        //temporarily
        private double amount = Configs.Config.premiumRate;
        public double Amount { get { return amount; } set { amount = value; OnPropertyChanged(); } }

        private string cover = Configs.Config.CoverType.ToString();
        private HomeQuotationResponseModel quotation;

        public string Cover { get { return cover; } set { cover = value; OnPropertyChanged(); } }
       

        public PaymentViewModel(QuatationResponseModel quatation)
        {
            PaymentCommmand = new Command(async () => await ExecutePaymentCommmand());
            this.Payment = this.quatation = quatation;
        }

        public PaymentViewModel(HomeQuotationResponseModel quotation)
        {
            this.quotation = quotation;
        }

        private async Task ExecutePaymentCommmand()

        {
            IsBusy = true;
            PaymentModel model = new PaymentModel() { Amount = 120 };

            var response = await Task.Run(() => HttpServices.Pay("api/Paynow/DebitExpress", model, out isSuccess));

            if (isSuccess)
            {
                var token = Configs.Config.Token;
                var result = JsonConvert.DeserializeObject<PaymentModelResponse>(response);
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Payment", "Thank you for chosing to insure with HostCare Insurance, Please Note you will be notified and given your Acount Details through an SMS once HostCare has confirmed your payment.", "Ok");

                await Application.Current.MainPage.Navigation.PushAsync(new HomePage(new HomeViewModel()));
                if (token != "")
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new DashboardPage(new VehicleInsuranceModel()));
                }
                else
                {
                    
                }
                
            }
            IsBusy = false;
        }
    }

    public class PaymentModel
    {
        public double Amount { get; set; }
    }


    public class PaymentModelResponse
    {
        public string phonenumber { get; set; }
        public float amount { get; set; }
        public string status { get; set; }
        public string instructions { get; set; }
        public string paynowreference { get; set; }
        public string pollurl { get; set; }
        public string hash { get; set; }
    }
}

