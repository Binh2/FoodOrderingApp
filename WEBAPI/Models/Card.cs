using System;

namespace WEBAPI.Models
{
    public interface ICard
    {
        int CardID { get; set; }
        string CardNumber { get; set; }
        string CardImage { get; set; }
        double CardBalance { get; set; }
        DateTime CardExpiryDate { get; set; }
        string CardType { get; set; }
    }
    public class Card : ICard, IConsumer, ICardType
    {
        public int CardID { get; set; }
        public string CardNumber { get; set; }
        public string CardImage { get; set; }
        public double CardBalance { get; set; }
        public DateTime CardExpiryDate { get; set; }
        public string CardType { get; set; }

        public int CardTypeID { get; set; }
        public string CardTypeName { get; set; }

        public int ConsumerID { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerEmail { get; set; }
        public string ConsumerImage { get; set; }
        public string ConsumerUsername { get; set; }
        public string ConsumerPassword { get; set; }
    }
}