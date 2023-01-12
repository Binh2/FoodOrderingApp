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

namespace FoodOrderingApp.ProducerPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFoodRestaurantPage : ContentPage
    {
        List<Foods> foodListConverted;
        public ListFoodRestaurantPage()
        {
            InitializeComponent();
            GetAllFood();
        }

        async void GetAllFood()
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllFoods");
            foodListConverted = JsonConvert.DeserializeObject<List<Foods>>(FoodList);
            lstfood.ItemsSource = foodListConverted;
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void searchfood_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchnamefood = foodListConverted.Where(s => s.FoodName.ToLower().Contains(searchfood.Text.ToLower()));
            lstfood.ItemsSource = searchnamefood;
        }

        private void lstfood_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void change_Clicked(object sender, EventArgs e)
        {
            var menuitem = ((MenuItem)sender);
            Foods food = menuitem.CommandParameter as Foods;



        }

        private void delete_Clicked_1(object sender, EventArgs e)
        {

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}