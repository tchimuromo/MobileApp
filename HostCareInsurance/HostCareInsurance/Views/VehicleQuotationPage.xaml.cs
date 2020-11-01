﻿using HostCareInsurance.Models;
using HostCareInsurance.Models.ViewModels;
using Plugin.Media;

using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HostCareInsurance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleQuotationPage : ContentPage
    {
        private readonly VehicleQuotationViewModel model;

        public VehicleQuotationPage(VehicleQuotationViewModel model)
        {
            InitializeComponent();
            BindingContext = this.model = model;
           
            //takePhoto.Clicked += async (sender, args) =>
            //{

            //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //    {
            //        await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
            //        return;
            //    }
            //    try
            //    {
            //        var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //        {
            //            Directory = "Sample",
            //            Name = "test.jpg",
            //            SaveToAlbum = saveToGallery.IsToggled
            //        });

            //        if (file == null)
            //            return;

            //        await DisplayAlert("File Location", (saveToGallery.IsToggled ? file.AlbumPath : file.Path), "OK");

            //        image.Source = ImageSource.FromStream(() =>
            //        {
            //            var stream = file.GetStream();
            //            file.Dispose();
            //            return stream;
            //        });
            //    }
            //    catch //(Exception ex)
            //    {
            //        // Xamarin.Insights.Report(ex);
            //        // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured it in Xamarin Insights! Thanks.", "OK");
            //    }
            //};

            //takePhoto.Clicked += async (sender, args) =>
            //{
            //    if (!CrossMedia.Current.IsPickPhotoSupported)
            //    {
            //        await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
            //        return;
            //    }
            //    try
            //    {
            //        Stream stream = null;
            //        var file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);


            //        if (file == null)
            //            return;

            //        stream = file.GetStream();
            //        file.Dispose();

            //        image.Source = ImageSource.FromStream(() => stream);

            //    }
            //    catch //(Exception ex)
            //    {
            //        // Xamarin.Insights.Report(ex);
            //        // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured it in Xamarin Insights! Thanks.", "OK");
            //    }
            //};




        }

        private void takePhoto_Clicked(object sender, EventArgs e)
        {

        }
    }
}