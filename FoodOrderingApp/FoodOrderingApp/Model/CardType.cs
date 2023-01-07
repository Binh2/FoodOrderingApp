using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public interface ICardType
    {
        int CardTypeID { get; set; }
        string CardTypeName { get; set; }
    }
    public class CardType : ICardType
    {
        public int CardTypeID { get; set; }
        public string CardTypeName { get; set; }
    }
}
