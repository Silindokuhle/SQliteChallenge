using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TshirtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        public Details()
        {
            InitializeComponent();
        }

        private async void cancel_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void save_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShirtItemPage());
        }
    }
}