using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class OrderStateController : ApiController
    {
        [Route("api/OrderStateController/SelectAllOrderStates")]
        [HttpGet]
        public IHttpActionResult SelectAllOrderStates()
        {
            try
            {
                //Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_SelectAllOrderStates");
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderStateController/SelectOrderStateByOrderID")]
        [HttpGet]
        public IHttpActionResult SelectOrderStateByUsername(string OrderID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(OrderID), OrderID);
                DataTable result = Database.Database.ReadTable("Proc_SelectOrderStateByOrderID", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/OrderStateController/InsertOrderState")]
        [HttpPost]
        public IHttpActionResult InsertOrderState(OrderState orderState)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(orderState.OrderID), orderState.OrderID);
                param.Add(nameof(orderState.OrderStateTypeID), orderState.OrderStateTypeID);
                param.Add(nameof(orderState.OrderDate), orderState.OrderDate);
                param.Add(nameof(orderState.OrderLocation), orderState.OrderLocation);
                var result = Database.Database.Exec_Command("Proc_InsertOrderState", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderStateController/UpdateOrderState")]
        [HttpPost]
        public IHttpActionResult UpdateOrderState(OrderState orderState)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(orderState.OrderStateID), orderState.OrderStateID);
                param.Add(nameof(orderState.OrderID), orderState.OrderID);
                param.Add(nameof(orderState.OrderStateTypeID), orderState.OrderStateTypeID);
                param.Add(nameof(orderState.OrderDate), orderState.OrderDate);
                param.Add(nameof(orderState.OrderLocation), orderState.OrderLocation);
                var result = Database.Database.Exec_Command("Proc_UpdateOrderState", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderStateController/DeleteOrderState")]
        [HttpPost]
        public IHttpActionResult DeleteOrderState(int OrderStateID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("OrderStateID", OrderStateID);
                var result = Database.Database.Exec_Command("Proc_DeleteOrderState", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
