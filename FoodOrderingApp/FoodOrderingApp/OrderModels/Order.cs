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
        public string FoodImages { get; set; }
        public int OrderStateTypeID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderLocation { get; set; }
    }
    static public class ORDER_STATE
    {
        public const int IN_RESTAURANT = 2;
        public const int IN_CART = 4;
        public const int SIGNING = 5;
        public const int SIGNED = 6;
        public const int PROCESSING = 7;
        public const int PROCESSED = 8;
        public const int SHIPPING = 9;
        public const int SHIPPED = 10;
        public const int RECEIVING = 11;
        public const int RECEIVED = 12;
    }
}
