﻿using FoodOrderingApp.Model;
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
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();
            ListViewInit();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategory");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            Lstcategories.ItemsSource = categoryListConverted;
        }
        async void ListViewInit()
        {
            HttpClient httpClient = new HttpClient();
            var categoryList = await httpClient.GetStringAsync("http://" + Constants.IP + "/WEBAPI/api/FoodController/GetAllCategory");
            var categoryListConverted = JsonConvert.DeserializeObject<List<Categories>>(categoryList);
            Lstcategories.ItemsSource = categoryListConverted;
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Lstcategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}