﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
{
    public interface IOrderState
    {
        int OrderStateID { get; set; }
        int OrderID { get; set; }
        int OrderStateTypeID { get; set; }
        DateTime OrderDate { get; set; }
        string OrderLocation { get; set; }
    }
    public class OrderState:IOrderState, IOrderStateType, IOrder
    {
        public int OrderStateID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderLocation { get; set; }
        
        public int OrderID { get; set; }
        public int ConsumerID { get; set; }

        public int OrderStateTypeID { get; set; }
        public string OrderStateTypeName { get; set; }
        public int OrderStateTypeIsDone { get; set; }
    }
}