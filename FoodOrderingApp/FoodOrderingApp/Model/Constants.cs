using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FoodOrderingApp.Model
{
    static public class Constants
    {
        // Binh
        public static readonly string IP = "192.168.1.48";

        // Thien
        //public static readonly string IP = "192.168.2.13";

        public static class ProcURL
        {
            public static readonly string GET_ALL_CARDS = "http://" + IP + "/webapi/api/CardController/GetAllCards";
            public static readonly string INSERT_CARD = "http://" + IP + "/webapi/api/CardController/InsertCard";
            public static readonly string DELETE_CARD = "http://" + IP + "/webapi/api/CardController/DeleteCard";
            
            public static readonly string SELECT_ALL_CONSUMERS = "http://" + IP + "/webapi/api/ConsumerController/SelectAllConsumers";
            public static readonly string SELECT_CONSUMER_BY_USERNAME = "http://" + IP + "/webapi/api/ConsumerController/SelectConsumerByUsername";
            public static readonly string SELECT_CONSUMER_BY_EMAIL = "http://" + IP + "/webapi/api/ConsumerController/SelectConsumerByEmail";
            public static readonly string INSERT_CONSUMER = "http://" + IP + "/webapi/api/ConsumerController/InsertConsumer";
            public static readonly string UPDATE_CONSUMER = "http://" + IP + "/webapi/api/ConsumerController/UpdateConsumer";
            public static readonly string DELETE_CONSUMER = "http://" + IP + "/webapi/api/ConsumerController/DeleteConsumer";
        }
    }
}
