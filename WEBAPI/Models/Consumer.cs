using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
{
    public interface IConsumer
    {
        int ConsumerID { get; set; }
        string ConsumerName { get; set; }
        string ConsumerEmail { get; set; }
        string ConsumerImage { get; set; }
        string ConsumerUsername { get; set; }
        string ConsumerPassword { get; set; }
    }
    public class Consumer : IConsumer
    {
        public int ConsumerID { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerEmail { get; set; }
        public string ConsumerImage { get; set; }
        public string ConsumerUsername { get; set; }
        public string ConsumerPassword { get; set; }
    }
}