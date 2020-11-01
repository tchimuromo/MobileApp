using HostCareInsurance.Views;
using MobileApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HostCareInsurance.Models.ViewModels
{
    public class HomeQuotationViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private List<ConstructionType> listConstructionTypes;
        public List<ConstructionType> ListConstructionTypes 
        {
            get { return listConstructionTypes; }
            set 
            {
                if (Equals(value, listConstructionTypes)) return;
                listConstructionTypes = value;
                OnPropertyChanged();
            }
        }
        private List<InsurancePremium> listInsurancePremium;
        public List<InsurancePremium> ListInsurancePremium
        {
            get { return listInsurancePremium; }
            set
            {
                if (Equals(value, listInsurancePremium)) return;
                listInsurancePremium = value;
                OnPropertyChanged();
            }
        }
        private InsurancePremium premia { get; set; }

        public InsurancePremium Premia
        {
            get { return premia; }
            set
            {
                if (premia != value)
                {
                    premia = value;
                    Premium = premia.Name;
                }
            }
        }
        private string premium;

        public string Premium
        {
            get { return premium; }
            set
            {
                if (premium != value)
                    premium = value; OnPropertyChanged();
            }
        }
        public static List<InsurancePremium> GetInsurancePremia()
        {
            var insurancePremia = new List<InsurancePremium>()
            {
                new InsurancePremium(){Key=1, Name ="Annual Premium"},
                new InsurancePremium(){Key=2, Name ="Monthly Premium"},
                new InsurancePremium(){Key=3, Name ="Termly Premium"},
                new InsurancePremium(){Key=4, Name ="Quarterly Premium"},
            };
            return insurancePremia;
        }

        public Command HomeQuotationCommand { get; set; }

        private string address;
        public string Address { 
            get {
                return address;
            } 
            set {
                address = value; OnPropertyChanged();
            } 
        }
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        private string owner;

        public string Owner
        {
            get { return owner; }
            set { owner = value; OnPropertyChanged(); }
        }

        private double propertyValue;

        public double PropertyValue
        {
            get { return propertyValue; }
            set { propertyValue = value; OnPropertyChanged(); }
        }
        private ConstructionType construction;
        public ConstructionType Construction 
        {
            get { return construction; }
            set 
            {
                if(construction != value)
                {
                    construction = value;
                    TypeOfConstruction = construction.Name;
                }
            }
        }

        private string type;
             public string TypeOfConstruction
        {
            get { return type; }
            set { type = value; OnPropertyChanged(); }
        }
        public HomeQuotationViewModel()
        {
            ListConstructionTypes = GetConstructionTypes();
            HomeQuotationCommand = new Command(async () => await ExecuteQuotation());
            ListInsurancePremium = GetInsurancePremia();
        }
        public static List<ConstructionType> GetConstructionTypes()
        {
            var constructiontypes = new List<ConstructionType>()
            {
                new ConstructionType(){Key=1, Name="Brick Under Tile"},
                new ConstructionType(){Key=2, Name="Brick Under Thatch"},
                new ConstructionType(){Key=3, Name="Brick Under IBR"},
                new ConstructionType(){Key=4, Name="Brick Under Asbestos"}

            };
            return constructiontypes;
        }

        private async Task ExecuteQuotation()
        {
            IsBusy = true;
            HomeInsuranceModel homeInsurance = new HomeInsuranceModel
            {
                Owner = Configs.Config.Username,
                PropertyValue = PropertyValue,
                Address = Address,
                TypeOfConstruction= TypeOfConstruction,
                Premium= Premium

                
            };
            var json = JsonConvert.SerializeObject(homeInsurance);
            var response = await Task.Run(() => HttpServices.Post("HomeInsurance", json));
            isBusy = false;
            if (response != null)
            {

                var quotation = JsonConvert.DeserializeObject<HomeQuotationResponseModel>(response);
                Configs.Config.premiumRate = quotation.InsuredAmount;
                await Application.Current.MainPage.Navigation.PushAsync(new HomePaymentPage(new PaymentViewModel(quotation)));
            }
        }
    }
}
