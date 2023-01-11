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
    public class RestaurantController : ApiController
    {
        [Route("api/RestaurantController/SelectAllRestaurants")]
        [HttpGet]
        public IHttpActionResult SelectAllRestaurants()
        {
            try
            {
                //Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_SelectAllRestaurants");
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/RestaurantController/SelectRestaurantsByConsumerID")]
        [HttpGet]
        public IHttpActionResult SelectRestaurantsByConsumerID(int ConsumerID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(ConsumerID), ConsumerID);
                DataTable result = Database.Database.ReadTable("Proc_SelectRestaurantsByConsumerID", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/RestaurantController/InsertRestaurant")]
        [HttpPost]
        public IHttpActionResult InsertRestaurant(Restaurant restaurant)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(restaurant.RestaurantName), restaurant.RestaurantName);
                param.Add(nameof(restaurant.RestaurantImage), restaurant.RestaurantImage);
                param.Add(nameof(restaurant.RestaurantLocation), restaurant.RestaurantLocation);
                var result = Database.Database.Exec_Command("Proc_InsertRestaurant", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/RestaurantController/UpdateRestaurant")]
        [HttpPost]
        public IHttpActionResult UpdateRestaurant(Restaurant restaurant)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(restaurant.RestaurantID), restaurant.RestaurantID);
                param.Add(nameof(restaurant.RestaurantName), restaurant.RestaurantName);
                param.Add(nameof(restaurant.RestaurantImage), restaurant.RestaurantImage);
                param.Add(nameof(restaurant.RestaurantLocation), restaurant.RestaurantLocation);
                var result = Database.Database.Exec_Command("Proc_UpdateRestaurant", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/RestaurantController/DeleteRestaurant")]
        [HttpPost]
        public IHttpActionResult DeleteRestaurant(int RestaurantID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(RestaurantID), RestaurantID);
                var result = Database.Database.Exec_Command("Proc_DeleteRestaurant", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
