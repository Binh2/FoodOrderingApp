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
    public class OrderFoodController : ApiController
    {
        [Route("api/OrderFoodController/SelectAllOrderFoods")]
        [HttpGet]
        public IHttpActionResult SelectAllOrderFoods()
        {
            try
            {
                //Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_SelectAllOrderFoods");
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderFoodController/SelectOrderFoodsByFoodID")]
        [HttpGet]
        public IHttpActionResult SelectOrderFoodsByFoodID(int FoodID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(FoodID), FoodID);
                DataTable result = Database.Database.ReadTable("Proc_SelectOrderFoodsByFoodID", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/OrderFoodController/InsertOrderFood")]
        [HttpPost]
        public IHttpActionResult InsertOrderFood(OrderFood orderFood)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(orderFood.OrderID), orderFood.OrderID);
                param.Add(nameof(orderFood.FoodID), orderFood.FoodID);
                param.Add(nameof(orderFood.FoodQuantity), orderFood.FoodQuantity);
                param.Add(nameof(orderFood.FoodPrice), orderFood.FoodPrice);
                var result = Database.Database.Exec_Command("Proc_InsertOrderFood", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderFoodController/UpdateOrderFood")]
        [HttpPost]
        public IHttpActionResult UpdateOrderFood(OrderFood orderFood)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(orderFood.OrderFoodID), orderFood.OrderFoodID);
                param.Add(nameof(orderFood.OrderID), orderFood.OrderID);
                param.Add(nameof(orderFood.FoodID), orderFood.FoodID);
                param.Add(nameof(orderFood.FoodQuantity), orderFood.FoodQuantity);
                param.Add(nameof(orderFood.FoodPrice), orderFood.FoodPrice);
                var result = Database.Database.Exec_Command("Proc_UpdateOrderFood", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/OrderFoodController/DeleteOrderFood")]
        [HttpPost]
        public IHttpActionResult DeleteOrderFood(int OrderFoodID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(OrderFoodID), OrderFoodID);
                var result = Database.Database.Exec_Command("Proc_DeleteOrderFood", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
