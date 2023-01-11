using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrderingApp.OrderModels
{
    public interface IOrderStateType
    {
        int OrderStateTypeID { get; set; }
        string OrderStateTypeName { get; set; }
        bool OrderStateTypeIsDone { get; set; }
    }
    public class OrderStateType : IOrderStateType
    {
        public int OrderStateTypeID { get; set; }
        public string OrderStateTypeName { get; set; }
        public bool OrderStateTypeIsDone { get; set; }
    }
}
