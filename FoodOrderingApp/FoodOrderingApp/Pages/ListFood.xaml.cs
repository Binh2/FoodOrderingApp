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
        public ListFood()
        {
            InitializeComponent();
            GetAllFood();   
        }

        async void GetAllFood()
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllFoods");
            var foodListConverted = JsonConvert.DeserializeObject<List<Foods>>(FoodList);
            listView.ItemsSource = foodListConverted;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Foods foods = (Foods)e.SelectedItem;
            Navigation.PushModalAsync(new NavigationPage(new FoodDetailPage(foods)));
        }
    }
}