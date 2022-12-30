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

    }
}
