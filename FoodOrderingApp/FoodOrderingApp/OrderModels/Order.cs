using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.OrderModels
{
    public interface IOrder
    {
        int OrderID { get; set; }
        int ConsumerID { get; set; }
    }

    public class Order : IOrder, IConsumer
    {
        // Nessesary
        public int OrderID { get; set; }

        public int ConsumerID { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerEmail { get; set; }
        public string ConsumerImage { get; set; }
        public string ConsumerUsername { get; set; }
        public string ConsumerPassword { get; set; }

        // not completely nessesary
        public int OrderPrice { get; set; }
        public string OrderImages { get; set; }
        public int OrderState { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderLocation { get; set; }
    }
    static public class ORDER_STATE
    {
        public const int IN_RESTAURANT = 0;
        public const int IN_CART = 1;
        public const int SIGNING = 2;
        public const int SIGNED = 3;
        public const int PROCESSING = 4;
        public const int PROCESSED = 5;
        public const int SHIPPING = 6;
        public const int SHIPPED = 7;
        public const int RECEIVED = 8;
    }
}
