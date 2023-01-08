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
    public partial class FoodPage : ContentPage
    {
        public FoodPage(Categories categories)
        {
            InitializeComponent();
            GetFoodsByCateID(categories.CategoryID);
        }
        async void GetFoodsByCateID(int CategoryID)
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetFoodsBycategoryID?CategoryId=" + CategoryID.ToString());
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