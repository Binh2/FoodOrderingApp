using FoodOrderingApp.Model;
using Newtonsoft.Json;
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
    public partial class FoodDetailPage : ContentPage
    {

        public FoodDetailPage(Foods food)
        {
            InitializeComponent();
            GetFood(food.FoodID);
        }

        async void GetFood(int foodID)
        {
            HttpClient httpClient = new HttpClient();

            var Food = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetFoodByID?foodid=" + foodID.ToString()); 
            var foodListConverted = JsonConvert.DeserializeObject<List<Foods>>(Food);
            food.ItemsSource = foodListConverted;
        }

        private void LstFood_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}