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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();
            ListViewbestrating();
            ListViewrcommend();
        }
        async void ListViewbestrating()
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/Proc_GetTOP4FoodByRATES");
            var FoodListConverted = JsonConvert.DeserializeObject<List<Foods>>(FoodList);
            Popular.ItemsSource = FoodListConverted;
        }

        async void ListViewrcommend()
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/Proc_GetTOP4FoodByRATES");
            var FoodListConverted = JsonConvert.DeserializeObject<List<Foods>>(FoodList);
            Recommend.ItemsSource = FoodListConverted;
        }
    }
}