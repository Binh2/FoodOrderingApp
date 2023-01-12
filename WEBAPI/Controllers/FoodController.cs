using System;
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

        [Route("api/FoodController/InsertFood")]
        [HttpPost]
        public IHttpActionResult InsertFood(Food food)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("FoodName", food.FoodName);
                param.Add("FoodImages", food.FoodImages);
                param.Add("CategoryID", food.CategoryID);
                param.Add("FoodPrice", food.FoodPrice);
                param.Add("FoodRating", food.FoodRating);
                param.Add("RestaurantID", food.RestaurantID);
                param.Add("FoodFavourite", food.FoodFavourite);
                var result = Database.Database.Exec_Command("Proc_InsertFood", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/FoodController/GetIDByCategoryName")]
        [HttpGet]
        public IHttpActionResult GetIDByCategoryName(string CategoryName)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("CategoryName", CategoryName);
                param.Add("IP", Constants.IP);
                DataTable result = Database.Database.ReadTable("Proc_GetIDByCategoryName", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/OrderController/UpdateFood")]
        [HttpPost]
        public IHttpActionResult UpdateFood(Food food)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("FoodID", food.FoodID);
                param.Add("FoodName", food.FoodName);
                param.Add("FoodImages", food.FoodImages);
                param.Add("CategoryID", food.CategoryID);
                param.Add("FoodPrice", food.FoodPrice);
                param.Add("FoodRating", food.FoodRating);
                param.Add("RestaurantID", food.RestaurantID);
                param.Add("FoodFavourite", food.FoodFavourite);
                var result = Database.Database.Exec_Command("Proc_UpdateFood", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/FoodController/DeleteFood")]
        [HttpPost]
        public IHttpActionResult DeleteFood(int FoodID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("FoodID", FoodID);
                var result = Database.Database.Exec_Command("Proc_DeleteFood", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

    }
}
