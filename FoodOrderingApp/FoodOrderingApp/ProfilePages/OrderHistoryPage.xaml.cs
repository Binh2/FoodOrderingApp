using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderingApp.ProfilePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderHistoryPage : ContentPage
    {
        List<Order> orderHistory;
        public OrderHistoryPage()
        {
            InitializeComponent();
            orderHistory = new List<Order>()
            {
                new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
                new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
                new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
                new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
                new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
            };
            collectionView.ItemsSource = orderHistory;
        }
    }
}