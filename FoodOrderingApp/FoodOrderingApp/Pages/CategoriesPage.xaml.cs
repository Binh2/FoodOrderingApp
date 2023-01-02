using FoodOrderingApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

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
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategory");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            Lstcategories.ItemsSource = categoryListConverted;
        }
        private void Lstcategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (e.CurrentSelection.FirstOrDefault() as Categories);
            Navigation.PushModalAsync(new NavigationPage(new FoodPage(current)));
        }       
    }
}