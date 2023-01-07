using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
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