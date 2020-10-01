using HostCareInsurance.Views;
using HostcareInsuranceBrokers.Models;
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
    public class VehicleQuotationViewModel:INotifyPropertyChanged
    {
        private List<VehicleMake> listVehicleMakes;
        public List<VehicleMake> ListVehicleMakes { 
            get { return listVehicleMakes; }
            set
            {
                if (Equals(value, listVehicleMakes)) return;
                listVehicleMakes = value;
                OnPropertyChanged();
            }
            }

        private List<InsurancePremium> listInsurancePremium;
        public List<InsurancePremium> ListInsurancePremium  {
            get { return listInsurancePremium; }
            set
            {
                if (Equals(value, listInsurancePremium)) return;
                listInsurancePremium = value;
                OnPropertyChanged();
            }
            }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string registrationNumber ;

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value; OnPropertyChanged(); }
        }
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }
        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; OnPropertyChanged(); }
        }

        private VehicleMake vehiclemake { get; set; }
        
        public VehicleMake Vehiclemake
        {
            get { return vehiclemake; }
            set
            {
                if (vehiclemake != value)
                {
                    vehiclemake = value;
                    Make = vehiclemake.Name;
                }
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
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged(); }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; OnPropertyChanged(); }
        }

      

        private string vehicleUse ;

        public string VehicleUse
        {
            get { return vehicleUse; }
            set { vehicleUse = value; OnPropertyChanged(); }
        }

        private string mileage;

        public string Mileage
        {
            get { return mileage; }
            set { mileage = value; OnPropertyChanged(); }
        }

        //private string courtesy = "ANY";

        //public string Courtesy
        //{
        //    get { return courtesy; }
        //    set { courtesy = value; OnPropertyChanged(); }
        //}
        private Guid iD = Guid.NewGuid();
        public Guid ID
        {
            get { return iD; }
            set { iD = value; OnPropertyChanged(); }
        }
        private string parkAddress;

        public string ParkAddress
        {
            get { return parkAddress; }
            set { parkAddress = value; OnPropertyChanged(); }
        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; OnPropertyChanged(); }
        }

        private string cover;

        public string Cover
        {
            get { return cover; }
            set { cover = value; OnPropertyChanged(); }
        }

        private byte[] photoPath1;

        public byte[] PhotoPath1
        {
            get { return photoPath1; }
            set { photoPath1 = value; OnPropertyChanged(); }
        }

        private byte[] photoPath2 ;

        public byte[] PhotoPath2
        {
            get { return photoPath2; }
            set { photoPath2 = value; OnPropertyChanged(); }
        }

        private byte[] photoPath3 ;

        public byte[] PhotoPath3
        {
            get { return photoPath3; }
            set { photoPath3 = value; OnPropertyChanged(); }
        }

        private byte[] photoPath4;

        public byte[] PhotoPath4
        {
            get { return photoPath4; }
            set { photoPath4 = value; OnPropertyChanged(); }
        }

        private string owner;

        public string Owner
        {
            get { return owner; }
            set { owner = value; OnPropertyChanged(); }
        }

        private string carValue;

        public string CarValue
        {
            get { return carValue; }
            set { carValue = value; OnPropertyChanged(); }
        }

        
                           

        public Command QuatationCommand { get; set; }

        public VehicleQuotationViewModel()
        {
            QuatationCommand = new Command(async () => await ExecuteQuatationCommand());
            ListVehicleMakes = GetMakes();
            ListInsurancePremium = GetInsurancePremia();
            
        }

        public static List<VehicleMake> GetMakes()
        {
            var makes = new List<VehicleMake>()
            {
                new VehicleMake(){Key=1, Name ="Toyota"},
                new VehicleMake(){Key=2, Name ="Nissan"},
                new VehicleMake(){Key=3, Name ="Benz"},
                new VehicleMake(){Key=4, Name ="Honda"},
            };
            return makes;
        }
        public static List<InsurancePremium> GetInsurancePremia()
        {
            var insurancePremia = new List<InsurancePremium>()
            {
                new InsurancePremium(){Key=1, Name ="AnnualPremium"},
                new InsurancePremium(){Key=2, Name ="MonthlyPremium"},
                new InsurancePremium(){Key=3, Name ="TermlyPremium"},
            };
            return insurancePremia;
        }

        private async Task ExecuteQuatationCommand()
        {
            IsBusy = true;

            VehicleInsuranceModel model = new VehicleInsuranceModel()
            {
                Color = Color,
                //Courtesy = Courtesy,
                Cover = Cover,
                ID = ID,
                Make = Make,
                Mileage = Mileage,
                Model = Model,
                Owner = Configs.Config.Username,
                ParkAddress = ParkAddress,
                PhotoPath1 = PhotoPath1,
                PhotoPath2 = PhotoPath2,
                PhotoPath3 = PhotoPath3,
                PhotoPath4 = PhotoPath4,
                Premium =Premium,
                RegistrationNumber = RegistrationNumber,
                Value = Convert.ToDouble(CarValue),
                VehicleUse = VehicleUse,
                Year = Year,
            };
            var json = JsonConvert.SerializeObject(model);
            var response = await Task.Run(() => HttpServices.Post("VehicleInsurance", json, ""));
            IsBusy = false;
            if (response != null)
            {
                var quatation = JsonConvert.DeserializeObject<QuatationResponseModel>(response);
                Configs.Config.premiumRate = quatation.PremiumRate;
               // Configs.Config.CoverType = quatation.Premium;
                await Application.Current.MainPage.Navigation.PushAsync(new PaymentPage(new PaymentViewModel(quatation)), true);


            }
            else
            {


            }
        }
    }
}

