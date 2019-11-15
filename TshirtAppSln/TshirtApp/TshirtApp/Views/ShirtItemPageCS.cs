using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TshirtApp.Views
{
    public class TshirtItemPageCS : ContentPage
    {
       
        public TshirtItemPageCS()
        {
            Title = "TshirtApp";

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var surnameEntry = new Entry();
            surnameEntry.SetBinding(Entry.TextProperty, "Surname");

            var GenderEntry = new Entry();
            GenderEntry.SetBinding(Entry.TextProperty, "Gender");

            var T_shirtsizeEntry = new Entry();
            T_shirtsizeEntry.SetBinding(Entry.TextProperty, "T_shirtsize");

            var T_shirtcolorEntry = new Entry();
            T_shirtcolorEntry.SetBinding(Entry.TextProperty, "T_shirtcolor");

            var DateoforderEntry = new Entry();
            DateoforderEntry.SetBinding(Entry.TextProperty, "Dateoforder");

            var ShippingaddressEntry = new Entry();
            ShippingaddressEntry.SetBinding(Entry.TextProperty, "ShippingAddress");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var tshirt = (Tshirt)BindingContext;
                await App.Database.SaveItemAsync(tshirt);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                  
                    saveButton,
                    cancelButton,
                    
                }
            };
        }
    }
}
