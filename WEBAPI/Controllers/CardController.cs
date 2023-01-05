using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WEBAPI.Controllers
{
    public class CardController : ApiController
    {
        [Route("api/CardController/GetAllCards")]
        [HttpGet]
        public IHttpActionResult GetAllCards()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetAllCards");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("api/CardController/InsertCard")]
        [HttpPost]
        public IHttpActionResult InsertCard()
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("CardNumber", "1234 5678");
                param.Add("CardImage", "card2.png");
                param.Add("CardTypeID", 2);
                param.Add("ConsumerID", 2);
                var result = Database.Database.Exec_Command("Proc_InsertCard", param);
                if (result != null)
                    return Ok(int.Parse(result.ToString()));
                return Ok("nullllllll");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/CardController/DeleteCard")]
        [HttpPost]
        public IHttpActionResult DeleteCard(int CardID)
        {
            try
            {
                var result = Database.Database.Exec_Command("Proc_InsertCard", new Dictionary<string, object>()
                {
                    { "CardID", CardID }
                });
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
