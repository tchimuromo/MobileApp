
using MobileApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsuaranceApp.ViewModel
{
    public class BaseViewModel : HttpServices, INotifyPropertyChanged
    {
        private bool isBusy;
        private bool isEnabled;
        private string title;
        public bool isSuccess;
        private string errorMessage;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; OnPropertyChanged(); }
        }

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; OnPropertyChanged(); }
        }

        private string successMessage;

        public string SuccessMessage
        {
            get { return successMessage; }
            set { successMessage = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public Command PopPageCommand { get; set; }

        public BaseViewModel()
        {
            PopPageCommand = new Command(async () => await ExecutePopPageCommand());
        }

        private async Task ExecutePopPageCommand()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// When operation started
        /// </summary>
        public void OperationStarted()
        {
            IsBusy = true;
            IsEnabled = false;
        }

        /// <summary>
        /// When operation completed
        /// </summary>
        public void OperationCompleted()
        {
            IsBusy = false;
            IsEnabled = true;
        }
    }
}
