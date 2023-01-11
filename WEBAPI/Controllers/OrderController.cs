using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class OrderController : ApiController
    {
        [Route("api/OrderController/SelectAllOrders")]
        [HttpGet]
        public IHttpActionResult SelectAllOrders()
        {
            try
            {
                //Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_SelectAllOrders");
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderController/SelectOrdersByConsumerID")]
        [HttpGet]
        public IHttpActionResult SelectOrdersByConsumerID(string ConsumerID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(ConsumerID), ConsumerID);
                DataTable result = Database.Database.ReadTable("Proc_SelectOrdersByConsumerID", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/OrderController/InsertOrder")]
        [HttpPost]
        public IHttpActionResult InsertOrder(Order order)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ConsumerID", order.ConsumerID);
                var result = Database.Database.Exec_Command("Proc_InsertOrder", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderController/UpdateOrder")]
        [HttpPost]
        public IHttpActionResult UpdateOrder(Order order)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("OrderID", order.OrderID);
                param.Add("ConsumerID", order.ConsumerID);
                var result = Database.Database.Exec_Command("Proc_UpdateOrder", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderController/DeleteOrder")]
        [HttpPost]
        public IHttpActionResult DeleteOrder(int OrderID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("OrderID", OrderID);
                var result = Database.Database.Exec_Command("Proc_DeleteOrder", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
