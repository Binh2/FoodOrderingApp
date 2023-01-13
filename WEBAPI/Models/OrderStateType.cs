using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
{
    public interface IOrderStateType
    {
        int OrderStateTypeID { get; set; }
        string OrderStateTypeName { get; set; }
        int OrderStateTypeIsDone { get; set; }
    }
    public class OrderStateType: IOrderStateType
    {
        public int OrderStateTypeID { get; set; }
        public string OrderStateTypeName { get; set; }
        public int OrderStateTypeIsDone { get; set; }
    }
}