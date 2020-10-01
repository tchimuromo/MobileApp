using HostCareInsurance.Models.ViewModels;
using MobileApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HostCareInsurance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            GetVehicle();
            GoRegisterCommand = new Command(async()=> await Quote());
            this.BindingContext = this;
            
           
    }

        public DashboardPage(VehicleInsuranceModel vehicleInsuranceModel)
        {
        }

        public void ShowOrHideVehicle(VehicleInsuranceModel vehicle)
        {

        }

        public async Task Quote()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new VehicleQuotationPage(new VehicleQuotationViewModel()));
        }

        // public IEnumerable<VehicleInsuranceModel> Vehicle { get => GetVehicle(); }
        /// ObservableCollection<VehicleInsuranceModel> Vehicle = new ObservableCollection<VehicleInsuranceModel>();
        public ObservableCollection<VehicleInsuranceModel> Vehicle { get; set; }
        public Command GoRegisterCommand { get; set; }

        private IEnumerable<VehicleInsuranceModel> GetVehicle()
        {
            var response = HttpServices.Get("VehicleInsurance", Configs.Config.Token, "");
           // var result = JsonConvert.DeserializeObject<ObservableCollection<VehicleInsuranceModel>>(response);
            var result = JsonConvert.DeserializeObject<IEnumerable<VehicleInsuranceModel>>(response).ToList();
            //List<VehicleInsuranceModel> vehicle = new List<VehicleInsuranceModel>();
            //foreach (var item in result)
            //{
            //    vehicle.Add(item);
            //}
            var email = Configs.Config.Username;
           // var r = vehicle.Where(e => e.Owner.Trim() == email).ToList();
            var o = (from data in result
                     where data.Owner.Trim().Equals(email)
                     select new VehicleInsuranceModel
                     {
                         ID = data.ID,
                         Color=data.Color,
                         Model = data.Model,
                         Make = data.Make,
                         ParkAddress = data.ParkAddress,
                         Cover = data.Cover,
                         RegistrationNumber = data.RegistrationNumber,
                         Mileage = data.Mileage,
                         Premium = data.Premium,
                         VehicleUse =data.VehicleUse,
                         Value =data.Value,
                         Year = data.Year,
                         Courtesy = data.Courtesy,
                         Owner = data.Owner,
                         PhotoPath1 =data.PhotoPath1,
                         PhotoPath2 = data.PhotoPath2,
                         PhotoPath3 = data.PhotoPath3,
                         PhotoPath4= data.PhotoPath4
                     }).ToList();
            Vehicle = new ObservableCollection<VehicleInsuranceModel>();

            foreach (var item in o)
            {
                
                Vehicle.Add(item);
            }

            return result;
            

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}