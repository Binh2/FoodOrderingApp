﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class ConsumerController : ApiController
    {

        [Route("api/ConsumerController/SelectAllConsumers")]
        [HttpGet]
        public IHttpActionResult SelectAllConsumers()
        {
            try
            {
                //Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_SelectAllConsumers");
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/ConsumerController/SelectConsumerByUsername")]
        [HttpGet]
        public IHttpActionResult SelectConsumerByUsername(string ConsumerUsername)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ConsumerUsername", ConsumerUsername);
                DataTable result = Database.Database.ReadTable("Proc_SelectConsumerByUsername", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/ConsumerController/InsertConsumer")]
        [HttpPost]
        public IHttpActionResult InsertConsumer(Consumer consumer)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ConsumerName", consumer.ConsumerName);
                param.Add("ConsumerEmail", consumer.ConsumerEmail);
                param.Add("ConsumerImage", consumer.ConsumerImage);
                param.Add("ConsumerUsername", consumer.ConsumerUsername);
                param.Add("ConsumerPassword", consumer.ConsumerPassword);
                var result = Database.Database.Exec_Command("Proc_InsertConsumer", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/ConsumerController/UpdateConsumer")]
        [HttpPost]
        public IHttpActionResult UpdateConsumer(Consumer consumer)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ConsumerID", consumer.ConsumerID);
                param.Add("ConsumerName", consumer.ConsumerName);
                param.Add("ConsumerEmail", consumer.ConsumerEmail);
                param.Add("ConsumerImage", consumer.ConsumerImage);
                param.Add("ConsumerPassword", consumer.ConsumerPassword);
                var result = Database.Database.Exec_Command("Proc_UpdateConsumer", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/ConsumerController/DeleteConsumer")]
        [HttpPost]
        public IHttpActionResult DeleteConsumer(int ConsumerID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ConsumerID", ConsumerID);
                var result = Database.Database.Exec_Command("Proc_DeleteConsumer", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}