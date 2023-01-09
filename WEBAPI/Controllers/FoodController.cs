﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEBAPI.Database;
using WEBAPI.Models;

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
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("IP", Constants.IP);
                DataTable result = Database.Database.ReadTable("Proc_GetAllCategories", param);
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
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("IP", Constants.IP);
                DataTable result = Database.Database.ReadTable("Proc_GetAllFoods", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/FoodController/Proc_GetTOP4FoodByRATES")]
        [HttpGet]
        public IHttpActionResult Proc_GetTOP4FoodByRATES()
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("IP", Constants.IP);
                DataTable result = Database.Database.ReadTable("Proc_GetTOP4FoodByRATES", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }



        [Route("api/FoodController/GetFoodsBycategoryID")]
        [HttpGet]
        public IHttpActionResult GetFoodsBycategoryID(int CategoryId)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("IP", Constants.IP);
                param.Add("CategoryID", CategoryId);
                DataTable result = Database.Database.ReadTable("Proc_GetFoodsBycategoryID", param);
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
                param.Add("IP", Constants.IP);
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
