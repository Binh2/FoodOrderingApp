using FoodOrderingApp.Model;
using FoodOrderingApp.OrderModels;
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
        List<OrderState> orderHistory;
        int? orderID = null;
        public OrderHistoryPage() { }
        public OrderHistoryPage(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
            //orderHistory = new List<Order>()
            //{
            //    new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
            //    new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
            //    new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
            //    new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
            //    new Order() { OrderDate = DateTime.Now, OrderState = ORDER_STATE.PROCESSED, OrderLocation = "Lagos State, Nigeria" },
            //};
            
            //collectionView.ItemsSource = orderHistory;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (orderID == null)
            {
                List<Order> orders =  await WebAPI.SelectOrdersByConsumerID(ConsumerProvider.consumer.ConsumerID);
                if (orders.Count > 0) orderID = orders[0].OrderID;
            }
            Title = orderID.ToString();
            orderHistory = await WebAPI.SelectAllOrderStates();
            collectionView.ItemsSource = orderHistory;
        }
    }
}