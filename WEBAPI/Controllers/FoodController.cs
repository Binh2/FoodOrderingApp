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

        [Route("api/FoodController/GetAllCategories")]
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetAllCategories");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/FoodController/GetAllFoods")]
        [HttpGet]
        public IHttpActionResult GetAllFoods()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetAllFoods");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
