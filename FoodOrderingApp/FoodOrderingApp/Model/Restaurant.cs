using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
    }
}
