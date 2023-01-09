using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WEBAPI.Models;

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
                Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_GetAllCards", param);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [Route("api/CardController/InsertCard")]
        [HttpPost]
        public IHttpActionResult InsertCard(Card card)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("CardNumber", card.CardNumber);
                param.Add("CardImage", card.CardImage);
                param.Add("CardExipryDate", card.CardExpiryDate);
                param.Add("Cardalance", card.CardBalance);
                param.Add("CardTypeID", card.CardTypeID);
                param.Add("ConsumerID", card.ConsumerID);
                var result = Database.Database.Exec_Command("Proc_InsertCard", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/CardController/UpdateCard")]
        [HttpPost]
        public IHttpActionResult UpdateCard(Card card)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("CardID", card.CardID);
                param.Add("CardNumber", card.CardNumber);
                param.Add("CardImage", card.CardImage);
                param.Add("CardExipryDate", card.CardExpiryDate);
                param.Add("Cardalance", card.CardBalance);
                param.Add("CardTypeID", card.CardTypeID);
                param.Add("ConsumerID", card.ConsumerID);
                var result = Database.Database.Exec_Command("Proc_UpdateCard", param);
                return Ok(int.Parse(result.ToString()));
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
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("CardID", CardID);
                var result = Database.Database.Exec_Command("Proc_DeleteCard", param);
                return Ok(int.Parse(result.ToString()));
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
