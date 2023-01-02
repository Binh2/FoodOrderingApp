using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Database;

namespace WEBAPI.Controllers
{
    public class FoodController : ApiController
    {
        [Route("api/FoodController/HelloWebAPI")]
        [HttpGet]
        public IHttpActionResult HelloWebAPI()
        {
            return Ok("Chào mừng bạn đến với Web API!");
        }

        [Route("api/FoodController/GetAllCategory")]
        [HttpGet]
        public IHttpActionResult GetAllCategory()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetAllCategory");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodController/GetAllFood")]
        [HttpGet]
        public IHttpActionResult GetAllFood()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetAllFood");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }



        [Route("api/FoodController/GetFoodBycategoryID")]
        [HttpGet]
        public IHttpActionResult GetFoodBycategoryID(int CategoryId)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("CategoryID", CategoryId);
                DataTable result = Database.Database.ReadTable("Proc_GetFoodBycategoryID", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodController/GetFoodByID")]
        [HttpGet]
        public IHttpActionResult GetFoodByID(int foodid)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("FoodID", foodid);
                DataTable result = Database.Database.ReadTable("Proc_GetFoodByID", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
