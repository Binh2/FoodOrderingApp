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
    public class CommentController : ApiController
    {
        [Route("api/CommentController/SelectAllComments")]
        [HttpGet]
        public IHttpActionResult SelectAllComments()
        {
            try
            {
                //Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_SelectAllComments");
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/CommentController/SelectCommentsByFoodID")]
        [HttpGet]
        public IHttpActionResult SelectCommentsByFoodID(int FoodID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(FoodID), FoodID);
                DataTable result = Database.Database.ReadTable("Proc_SelectCommentsByFoodID", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/CommentController/InsertComment")]
        [HttpPost]
        public IHttpActionResult InsertComment(Comment comment)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(comment.CommentStar), comment.CommentStar);
                param.Add(nameof(comment.CommentDetail), comment.CommentDetail);
                param.Add(nameof(comment.CommentDate), comment.CommentDate);
                param.Add(nameof(comment.FoodID), comment.FoodID);
                param.Add(nameof(comment.ConsumerID), comment.ConsumerID);
                var result = Database.Database.Exec_Command("Proc_InsertComment", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/CommentController/UpdateComment")]
        [HttpPost]
        public IHttpActionResult UpdateComment(Comment comment)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(comment.CommentID), comment.CommentID);
                param.Add(nameof(comment.CommentStar), comment.CommentStar);
                param.Add(nameof(comment.CommentDetail), comment.CommentDetail);
                param.Add(nameof(comment.CommentDate), comment.CommentDate);
                param.Add(nameof(comment.FoodID), comment.FoodID);
                param.Add(nameof(comment.ConsumerID), comment.ConsumerID);
                var result = Database.Database.Exec_Command("Proc_UpdateComment", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/CommentController/DeleteComment")]
        [HttpPost]
        public IHttpActionResult DeleteComment(int CommentID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(CommentID), CommentID);
                var result = Database.Database.Exec_Command("Proc_DeleteComment", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
