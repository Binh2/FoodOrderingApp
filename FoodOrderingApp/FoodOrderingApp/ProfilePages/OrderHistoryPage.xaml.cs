﻿using FoodOrderingApp.Model;
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
            orderHistory = await WebAPI.SelectOrderStatesByOrderID((int)orderID);
            for (int i = orderHistory.Count; i < 4; i++)
                orderHistory.Add(new OrderState()
                {
                    OrderStateID = i * 2 + 5,
                    OrderDate = DateTime.Now,
                    OrderLocation = "",
                    OrderStateTypeIsDone = 0
                });
            collectionView.ItemsSource = orderHistory;
        }

        private async void viewMapBtn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new OrderMapPage((int)orderID));
        }
    }
}