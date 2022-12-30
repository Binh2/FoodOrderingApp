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

namespace FoodOrderingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();
            ListViewInit();
        }
        async void ListViewInit()
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://192.168.2.13/WEBAPI/api/FoodController/GetAllCategory");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Category>>(categoryList);
            //LstSubject.ItemsSource = ListConverted;
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}