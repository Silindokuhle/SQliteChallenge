using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
       public List<Tshirt> Orders { get; set; }
       // public IList<Tshirt> orders { get; set; }

        public OrderPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var stuff = App.Database;
            Orders = await App.Database.GetItemsAsync();

            BindingContext = this;

        }

        //private async void Button_Clicked1(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new PlaceOrder());
        //}*/

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = e.Item as Tshirt;
            await Navigation.PushAsync(new PlaceOrder(SelectedItem));
        }

        //To check if the internet is working 
        /* private async void Button_Clicked(object sender, EventArgs e)
         {
             var current = Connectivity.NetworkAccess;
             if (current == NetworkAccess.Internet)
             {
                 await DisplayAlert("Connection", "Internet is working", "ok");
             }
             var databaseContent = App.Database;
             Orders = await databaseContent.GetItemsAsync();

             //Orders you want to display on the server
             var MyServerOrders = Orders.Select(x => new Tshirt()
             {
                 Name = x.Name,
                 Gender = x.Gender,
                 T_shirtsize = x.T_shirtsize,
                 Dateoforder = x.Dateoforder,
                 T_shirtcolor = x.T_shirtcolor,
                 ShippingAddress = x.ShippingAddress
             });
             //Placing the orders on the server
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
             } */
        //await Navigation.PushAsync(new SendToServer());
    }
    

}
