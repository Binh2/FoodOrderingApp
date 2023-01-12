using FoodOrderingApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.Pages
{
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();
            ListViewbestrating();
            ListViewInit3();
            ListViewrcommend();
            ListViewrcommend1();
        }
        async void ListViewbestrating()
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/Proc_GetTOP4FoodByRATES");
            var FoodListConverted = JsonConvert.DeserializeObject<List<Foods>>(FoodList);
            Popular.ItemsSource = FoodListConverted;
        }
        async void ListViewInit3()
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategories");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            cateview.ItemsSource = categoryListConverted;
        }
        async void ListViewrcommend()
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/Proc_GetTOP4NAME");
            var FoodListConverted = JsonConvert.DeserializeObject<List<Foods>>(FoodList);
            Recommend.ItemsSource = FoodListConverted;
        }
        async void ListViewrcommend1()
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllFoods");
            var FoodListConverted = JsonConvert.DeserializeObject<List<Foods>>(FoodList);
            foodcarouse.ItemsSource = FoodListConverted;
            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                foodcarouse.Position = (foodcarouse.Position + 1) % FoodListConverted.Count;
                return true;
            }));
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new ListFood());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            TapGestureRecognizer tapGestureRecognizer = frame.GestureRecognizers[0] as TapGestureRecognizer;
            Foods foods = tapGestureRecognizer.CommandParameter as Foods;
            await Shell.Current.Navigation.PushAsync(new FoodDetailPage(foods));

        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {

        }
    }
}