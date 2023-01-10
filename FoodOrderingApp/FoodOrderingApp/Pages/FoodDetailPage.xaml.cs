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

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            ImageButton bt = (ImageButton)sender;
            Foods hc = (Foods)bt.BindingContext;
            bool dachon = false;
            foreach (Foods h in ConsumerProvider.cart.Foods)
            {
                if (hc.FoodID == h.FoodID)
                {
                    h.FoodCount++;
                    dachon = true;
                    break;
                }
            }
            if (dachon == false)
            {
                hc.FoodCount = 1;
                ConsumerProvider.cart.Foods.Add(hc);
            }
            DisplayAlert("Thông báo", "Mua hàng thành công", "OK");
        }
    }   
}