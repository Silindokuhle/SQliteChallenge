using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceOrder : ContentPage
    {
        public List<Tshirt> Orders { get; set; }
        public Tshirt orders { get; set; }


        public PlaceOrder(Tshirt tshirt)
        {
            InitializeComponent();

            orders = tshirt;
            BindingContext = orders;
            
        }

        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //var stuff = App.Database;
            //orders = await App.Database.GetItemsAsync();

            //BindingContext = this;

        }


        private async void Button_Clicked1(object sender, EventArgs e)
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                await DisplayAlert("Connection", "Internet is working", "ok");
            }
            if (current != NetworkAccess.Internet)
            {
                await DisplayAlert("Connection", "Internet is not working", "ok");
            }
            var databaseContent = App.Database;

            Orders = await databaseContent.GetItemsAsync();
            var MyServerOrders = Orders.Select(x => new Tshirt()
            {
                Name = x.Name,
                Gender = x.Gender,
                T_shirtsize = x.T_shirtsize,
                Dateoforder = x.Dateoforder,
                T_shirtcolor = x.T_shirtcolor,
                ShippingAddress = x.ShippingAddress
            });
            var json = JsonConvert.SerializeObject(MyServerOrders);
            var client = new HttpClient();
            var url = "http://10.0.2.2:5000/products";
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(url, content);
                await DisplayAlert("Response Message", response.ReasonPhrase, "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception", ex.Message, "ok");
                //await Navigation.PushAsync(new SendToServer());
            }

        }


            

        private async void buttonClicked(object sender, EventArgs e)
        {
            var location = new Xamarin.Essentials.Location(45.345535, -156.777399);
            var options = new MapLaunchOptions { Name = "Angezwa" };
            await Map.OpenAsync(location, options);
               
        }
    }
}