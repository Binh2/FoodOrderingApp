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
    public class ProducerController : ApiController
    {
        [Route("api/ProducerController/SelectAllProducers")]
        [HttpGet]
        public IHttpActionResult SelectAllProducers()
        {
            try
            {
                //Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_SelectAllProducers");
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/ProducerController/SelectProducerByID")]
        [HttpGet]
        public IHttpActionResult SelectProducerByID(string ProducerID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(ProducerID), ProducerID);
                DataTable result = Database.Database.ReadTable("Proc_SelectProducerByID", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/ProducerController/SelectProducerByUsername")]
        [HttpGet]
        public IHttpActionResult SelectProducerByUsername(string ProducerUsername)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ProducerUsername", ProducerUsername);
                DataTable result = Database.Database.ReadTable("Proc_SelectProducerByUsername", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/ProducerController/SelectProducerByEmail")]
        [HttpGet]
        public IHttpActionResult SelectProducerByEmail(string ProducerEmail)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ProducerEmail", ProducerEmail);
                DataTable result = Database.Database.ReadTable("Proc_SelectProducerByEmail", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/ProducerController/InsertProducer")]
        [HttpPost]
        public IHttpActionResult InsertProducer(Producer producer)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ProducerName", producer.ProducerName);
                param.Add("ProducerEmail", producer.ProducerEmail);
                param.Add("ProducerImage", producer.ProducerImage);
                param.Add("ProducerUsername", producer.ProducerUsername);
                param.Add("ProducerPassword", producer.ProducerPassword);
                param.Add(nameof(producer.RestaurantID), producer.RestaurantID);
                var result = Database.Database.Exec_Command("Proc_InsertProducer", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/ProducerController/UpdateProducer")]
        [HttpPost]
        public IHttpActionResult UpdateProducer(Producer producer)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ProducerID", producer.ProducerID);
                param.Add("ProducerName", producer.ProducerName);
                param.Add("ProducerEmail", producer.ProducerEmail);
                param.Add("ProducerImage", producer.ProducerImage);
                param.Add("ProducerUsername", producer.ProducerUsername);
                param.Add("ProducerPassword", producer.ProducerPassword);
                param.Add(nameof(producer.RestaurantID), producer.RestaurantID);
                var result = Database.Database.Exec_Command("Proc_UpdateProducer", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/ProducerController/DeleteProducer")]
        [HttpPost]
        public IHttpActionResult DeleteProducer(int ProducerID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ProducerID", ProducerID);
                var result = Database.Database.Exec_Command("Proc_DeleteProducer", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
