using FoodOrderingApp.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public interface ICard
    {
        int CardID { get; set; }
        string CardNumber { get; set; }
        string CardImage { get; set; }
        DateTime CardExpiryDate { get; set; }
        string CardType { get; set; }
    }
    public class Card : ICard, IConsumer, ICardType, IBase
    {
        public string pluralTable { get; } = "Cards";
        public string uniqueColumn { get; set; } = "CardNumber";
        public string IDColumn { get; } = "CardID";
        public List<string> parameterColumns { get; } = new List<string>() { "CardNumber", "CardImage", "CardExpiryDate", "CardTypeID", "ConsumerID" };

        public int CardID { get; set; }
        public string CardNumber { get; set; }
        public string CardImage { get; set; }
        public DateTime CardExpiryDate { get; set; }
        public string CardType { get; set; }

        public int CardTypeID { get; set; }
        public string CardTypeName { get; set; }

        public int ConsumerID { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerEmail { get; set; }
        public string ConsumerImage { get; set; }
        public string ConsumerPassword { get; set; }
    }
}
