using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
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
}