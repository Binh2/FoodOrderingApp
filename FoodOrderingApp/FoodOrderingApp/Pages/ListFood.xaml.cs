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
    public partial class ListFood : ContentPage
    {
        List<Foods> foodListConverted;
        public ListFood()
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
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            TapGestureRecognizer tapGestureRecognizer = frame.GestureRecognizers[0] as TapGestureRecognizer;
            Foods foods = tapGestureRecognizer.CommandParameter as Foods;
            await Shell.Current.Navigation.PushAsync(new FoodDetailPage(foods));
        }

        private void searchfood_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchnamefood = foodListConverted.Where(s => s.FoodName.ToLower().Contains(searchfood.Text.ToLower()));
            lstfood.ItemsSource = searchnamefood;
        }

        private void lstfood_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Foods foods = (Foods)e.SelectedItem;
            Navigation.PushModalAsync(new NavigationPage(new FoodDetailPage(foods)));
        }
    }
}