using FoodOrderingApp.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.Model
{
    public interface ICard
    {
        [OperationType("Insert")]
        int CardID { get; set; }
        [OperationType("Insert")]
        string CardNumber { get; set; }
        string CardImage { get; set; }
        DateTime CardExpiryDate { get; set; }
        string CardType { get; set; }
    }
    public class Card : ICard, IConsumer, ICardType, IBase
    {
        public string pluralTable { get; } = "Cards";
        public string byColumn { get; set; }
        public object byValue { get; set; }

        public int CardID { get; set; }
        [OperationType("Insert")]
        public string CardNumber { get; set; }
        [OperationType("Insert")]
        public string CardImage { get; set; }
        [OperationType("Insert")]
        public DateTime CardExpiryDate { get; set; }
        [OperationType("Insert")]
        public string CardType { get; set; }

        [OperationType("Insert")]
        public int CardTypeID { get; set; }
        public string CardTypeName { get; set; }

        [OperationType("Insert")]
        public int ConsumerID { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerEmail { get; set; }
        public string ConsumerImage { get; set; }
        public string ConsumerPassword { get; set; }
    }
}
