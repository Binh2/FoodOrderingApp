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
        int FoodID { get; set; }
    }

    public class Order : IOrder, IConsumer, IFood
    {
        public int OrderID { get; set; }

        public int ConsumerID { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerEmail { get; set; }
        public string ConsumerImage { get; set; }
        public string ConsumerUsername { get; set; }
        public string ConsumerPassword { get; set; }

        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodImages { get; set; }
        public string FoodDetail { get; set; }
        public double FoodPrice { get; set; }
        public double FoodRating { get; set; }
        public int FoodFavourite { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }
    }
}