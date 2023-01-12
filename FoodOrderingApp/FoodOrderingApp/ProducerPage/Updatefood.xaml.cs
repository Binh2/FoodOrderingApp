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
    public partial class Updatefood : ContentPage
    {
        public Updatefood()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = null;
           // BindingContext = ;
        }

        private void UpdateBtn_Clicked(object sender, EventArgs e)
        {
            string image = FoodImage.Text,
                   name = FoodName.Text,
                   //category = pikcategory.Text,
                   price  =  Foodprice.Text,
                   detail =  FoodDetail.Text;
        }

        private async void pikcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategories");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            pikcategory.ItemsSource = categoryListConverted;
        }

        private void FoodDetail_Completed(object sender, EventArgs e)
        {

        }
    }
}