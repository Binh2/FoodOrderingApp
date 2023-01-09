using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public class Cart
    {
        public int Idcart { get; set; }
        public string Addressbuy { get; set; }
        public string cmt { get; set; }
        public List<Foods> Foods { get; set; }
    }
}
