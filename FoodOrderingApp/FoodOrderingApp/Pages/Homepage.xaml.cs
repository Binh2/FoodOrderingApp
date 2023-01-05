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
        public ICommand MyCommand => new Command(OnForgotPassword);
        private void OnForgotPassword()
        {
            Navigation.PushModalAsync(new NavigationPage(new CategoriesPage()));
        }
        public Homepage()
        {
            InitializeComponent();
            ListViewInit();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategories");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            Lstcategories.ItemsSource = categoryListConverted;
        }
        async void ListViewInit()
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategories");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            Lstcategories.ItemsSource = categoryListConverted;
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Lstcategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (e.CurrentSelection.FirstOrDefault() as Categories);
            Navigation.PushModalAsync(new FoodPage(current));
        }
    }
}