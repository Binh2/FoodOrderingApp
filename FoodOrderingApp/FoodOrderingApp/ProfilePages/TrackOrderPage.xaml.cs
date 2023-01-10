using FoodOrderingApp.Model;
using FoodOrderingApp.OrderModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackOrderPage : ContentPage
    {
        List<Order> orders;
        public TrackOrderPage()
        {
            InitializeComponent();
            Title = "Track Order";
            //orders = new List<Order>()
            //{
            //    new Order() { OrderID = 1, OrderDate = DateTime.Now, OrderImages = "pizza.png|fruits.png|hot_dog.png|hamburger_and_chips.png", 
            //        OrderPrice = 11, OrderState = ORDER_STATE.PROCESSED },
            //    new Order() { OrderID = 2, OrderDate = DateTime.Now, OrderImages = "fruits.png", OrderPrice = 15, OrderState = ORDER_STATE.RECEIVED },
            //    new Order() { OrderID = 3, OrderDate = DateTime.Now, OrderImages = "hot_dog.png", OrderPrice = 5, OrderState = ORDER_STATE.SHIPPING },
            //    new Order() { OrderID = 4, OrderDate = DateTime.Now, OrderImages = "hamburger_and_chips.png", OrderPrice = 7, OrderState = ORDER_STATE.SIGNED }
            //};
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            orders = await WebAPI.SelectAllOrders();
            collectionView.ItemsSource = orders;
        }
    }
}