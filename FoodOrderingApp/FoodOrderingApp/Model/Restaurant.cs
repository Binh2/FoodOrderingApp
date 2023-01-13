﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public interface IRestaurant
    {
        int RestaurantID { get; set; }
        string RestaurantName { get; set; }
        string RestaurantImage { get; set; }
        string RestaurantLocation { get; set; }
    }

    public class Restaurant : IRestaurant
    {
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantImage { get; set; }
        public string RestaurantLocation { get; set; }
    }
}
