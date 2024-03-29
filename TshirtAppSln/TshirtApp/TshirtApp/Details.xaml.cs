﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        public List<Tshirt> TshirtOrder { get; set; }
        public Details()
        {
            InitializeComponent();
        }

        private async void cancel_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var tshirt = new Tshirt();
            BindingContext = tshirt;
        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var tshirt = (Tshirt)BindingContext;

            var location = tshirt.ShippingAddress;
            var myadd = "Makhaza Cape Town";
            var locate = await Geocoding.GetLocationsAsync(myadd);
            Location finalLocate = locate?.FirstOrDefault();
            var addPos = string.Empty;
            if (finalLocate != null)
            {
                addPos = $"Latitude: {finalLocate.Latitude}, Longitude: {finalLocate.Longitude}";
            }
            tshirt.AddressPosition = addPos;

            await App.Database.SaveItemAsync(tshirt);
            await Navigation.PushAsync(new OrderPage());
        }
    }
}