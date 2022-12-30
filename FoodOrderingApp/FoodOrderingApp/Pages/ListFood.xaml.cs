using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFood : ContentPage
    {
        public ListFood()
        {
            InitializeComponent();
        }

       
        private async void CmdHelloWEBAPI_Clicked_1(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();

            var result = await httpClient.GetStringAsync("http://192.168.2.13/WEBAPI/api/FoodController/HelloWebAPI");
            LbHello.Text = result;
            LbHello.TextColor = Color.Red;
        }
    }
}