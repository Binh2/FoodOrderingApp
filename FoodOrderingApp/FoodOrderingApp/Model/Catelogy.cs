using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FoodOrderingApp.Model
{
    public class Catelogy
    {
        [PrimaryKey,AutoIncrement]
        public int CatelogyID { get; set; }
        public string CatelogyName { get; set; }
        public string CatelogyImages { get; set; }
        public string CatelogyLink { get; set;}


    }
}
