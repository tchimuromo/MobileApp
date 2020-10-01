using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

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
        private string address;
        public string Address { 
            get {
                return address;
            } 
            set {
                address = value; OnPropertyChanged();
            } 
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
                    Type = construction.Name;
                }
            }
        }

        private string type;
             public string Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(); }
        }
        public HomeQuotationViewModel()
        {
            ListConstructionTypes = GetConstructionTypes();
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
    }
}
