using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Categories
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }

    }
}
