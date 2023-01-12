using FoodOrderingApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class CategoriesPage : ContentPage

    {
        public CategoriesPage()
        {
            InitializeComponent();
            ListViewInit();
        }      
        async void ListViewInit()
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategories");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            lstcategory.ItemsSource = categoryListConverted;
        }

        private void lstcategory_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var current = (Categories)e.SelectedItem;
            Navigation.PushModalAsync(new NavigationPage(new FoodPage(current)));
        }
    }
}