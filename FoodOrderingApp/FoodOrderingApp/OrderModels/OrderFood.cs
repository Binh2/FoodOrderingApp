﻿using FoodOrderingApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.OrderModels
{
    public interface IOrderFood
    {
        int OrderFoodID { get; set; }
        int OrderID { get; set; }
        int FoodID { get; set; }
        int FoodQuantity { get; set; }
        double FoodPrice { get; set; }
    }
    public class OrderFood : IOrderFood, IOrder, IFood
    {
        public int OrderFoodID { get; set; }
        public int FoodQuantity { get; set; }
        public double FoodPrice { get; set; }

        public int OrderID { get; set; }
        public int ConsumerID { get; set; }

        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodImages { get; set; }
        public string FoodDetail { get; set; }
        public double FoodRating { get; set; }
        public int FoodFavourite { get; set; }
        public int CategoryID { get; set; }
        public int RestaurantID { get; set; }
    }
}
