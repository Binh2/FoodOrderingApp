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
        int foodID;
        public List<Comment> comments;
        public FoodDetailPage(Foods food)
        {
            InitializeComponent();
            foodID = food.FoodID;
            GetFood(food.FoodID);
        }

        async void GetFood(int foodID)
        {
            HttpClient httpClient = new HttpClient();

            var Food = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetFoodByID?foodid=" + foodID.ToString()); 
            var foodListConverted = JsonConvert.DeserializeObject<List<Foods>>(Food);
            Foods food = (new List<Foods>(foodListConverted)).First();
            Title = food.FoodName;
            foodListView.ItemsSource = foodListConverted;
        }

        protected async override void OnAppearing()
        {
            // Comment section
            base.OnAppearing();
            //Title = foodID.ToString();
            comments = await WebAPI.SelectCommentsByFoodID(foodID);
            if (comments != null) collectionView.ItemsSource = comments;
        }

        private void LstFood_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {

        }
        private void addToCart_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Foods food = (Foods)button.CommandParameter;
            bool isAdded = ConsumerProvider.AddFood(food);
            if (isAdded)
                DisplayAlert("Added food to cart successfully", "", "Close");
            else DisplayAlert("The food is already added to cart", "", "Close");
        }
    }   
}