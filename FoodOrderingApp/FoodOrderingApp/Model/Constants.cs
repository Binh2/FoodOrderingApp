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

            public static readonly string GET_ALL = "http://" + IP + "/webapi/api/BaseController/GetAll";
            public static readonly string GET_BY = "http://" + IP + "/webapi/api/BaseController/GetBy";
            public static readonly string INSERT = "http://" + IP + "/webapi/api/BaseController/Insert";
            public static readonly string UPDATE = "http://" + IP + "/webapi/api/BaseController/Update";
            public static readonly string DELETE = "http://" + IP + "/webapi/api/BaseController/Delete";
        }
    }
}
