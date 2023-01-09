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
    public class BaseController : ApiController
    {
        private IHttpActionResult ExceptionHandling(Exception e)
        {
            return Ok(e.Message);
            //return NotFound();
        }
        [Route("api/BaseController/GetBy")]
        [HttpGet]
        public IHttpActionResult GetBy(string pluralTable, string byColumn, string byValue)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("pluralTable", pluralTable);
                param.Add("byColumn", byColumn);
                param.Add("byValue", byValue);
                DataTable result = Database.Database.ReadTable("Proc_GetBy", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return ExceptionHandling(e);
            }
        }
        [Route("api/BaseController/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll(string pluralTable)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("pluralTable", pluralTable);
                DataTable result = Database.Database.ReadTable("Proc_GetAll", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return ExceptionHandling(e);
            }
        }

        [Route("api/BaseController/Insert")]
        [HttpPost]
        public IHttpActionResult Insert(string pluralTable, string parameterColumns, string parameterValues, string uniqueColumn, string uniqueValue)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("pluralTable", pluralTable);
                param.Add("parameterColumns", parameterColumns);
                param.Add("parameterValues", parameterValues);
                param.Add("uniqueColumn", uniqueColumn);
                param.Add("uniqueValue", uniqueValue);
                var result = Database.Database.Exec_Command("Proc_Insert", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return ExceptionHandling(e);
            }
        }
        [Route("api/BaseController/Update")]
        [HttpPost]
        public IHttpActionResult Update(string pluralTable, string parameters, string uniqueColumn, string uniqueValue, string IDColumn, string IDValue)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("pluralTable", pluralTable);
                param.Add("parameters", parameters);
                param.Add("uniqueColumn", uniqueColumn);
                param.Add("uniqueValue", uniqueValue);
                param.Add("IDColumn", IDColumn);
                param.Add("IDValue", IDValue);
                var result = Database.Database.Exec_Command("Proc_Update", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return ExceptionHandling(e);
            }
        }
        [Route("api/BaseController/Delete")]
        [HttpPost]
        public IHttpActionResult Delete(string pluralTable, string IDColumn, string IDValue)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("pluralTable", pluralTable);
                param.Add("uniqueColumn", IDColumn);
                param.Add("uniqueValue", IDValue);
                param.Add("IDColumn", IDColumn);
                param.Add("IDValue", IDValue);
                var result = Database.Database.Exec_Command("Proc_Delete", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return ExceptionHandling(e);
            }
        }

        [Route("api/BaseController/Post")]
        [HttpPost]
        public IHttpActionResult Post(string proc)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("proc", proc);
                var result = Database.Database.Exec_Command("Proc_Post", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return ExceptionHandling(e);
            }
        }
        [Route("api/BaseController/Get")]
        [HttpGet]
        public IHttpActionResult Get(string proc)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("proc", proc);
                DataTable result = Database.Database.ReadTable("Proc_Get", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return ExceptionHandling(e);
            }
        }
    }
}
