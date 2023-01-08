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
            ListViewInit();
            ListViewbestrating();
        }
        async void ListViewInit()
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategories");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            Lstcategories.ItemsSource = categoryListConverted;
        }

        async void ListViewbestrating()
        {
            HttpClient httpClient = new HttpClient();
            var FoodList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/Proc_GetTOP4FoodByRATES");
            var FoodListConverted = JsonConvert.DeserializeObject<List<Categories>>(FoodList);
            listView1.ItemsSource = FoodListConverted;
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Lstcategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (e.CurrentSelection.FirstOrDefault() as Categories);
            Navigation.PushModalAsync(new FoodPage(current));
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CategoriesPage());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            TapGestureRecognizer tapGestureRecognizer = frame.GestureRecognizers[0] as TapGestureRecognizer;
            Categories cate = tapGestureRecognizer.CommandParameter as Categories;
            await Shell.Current.Navigation.PushAsync(new FoodPage(cate));

        }

        private void listView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}