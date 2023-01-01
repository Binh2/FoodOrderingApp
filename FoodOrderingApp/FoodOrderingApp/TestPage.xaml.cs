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

namespace FoodOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }

        private async void helloBtn_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string url = "http://" + Constants.IP + "/webapi/api/FoodController/HelloWebAPI";
            var text = await httpClient.GetStringAsync(url);
            var textConverted = JsonConvert.DeserializeObject<string>(text);
            label.Text = text;
        }

        private async void getCategoriesBtn_Clicked(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategory");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Category>>(categoryList);
            listView.ItemsSource = categoryListConverted;
            label.Text = categoryListConverted[0].CategoryName;
        }
    }
}