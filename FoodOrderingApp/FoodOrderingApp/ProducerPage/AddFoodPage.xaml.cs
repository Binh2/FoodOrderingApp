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
    public partial class AddFoodPage : ContentPage
    {
        public AddFoodPage()
        {
            InitializeComponent();
            Title = "Add Food";
            PickerInit();
        }
        async void PickerInit()
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategories");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            pikcategory.ItemsSource = categoryListConverted;
        }
        private void addBtn_Clicked(object sender, EventArgs e)
        {
             
        }     
        private void consumerConfirmPassword_Completed(object sender, EventArgs e)
        {

        }

        private void pikcategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}