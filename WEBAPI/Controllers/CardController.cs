using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    public class CardController : ApiController
    {
        [Route("api/CardController/SelectAllCards")]
        [HttpGet]
        public IHttpActionResult SelectAllCards()
        {
            try
            {
                //Dictionary<string, object> param = new Dictionary<string, object>();
                DataTable result = Database.Database.ReadTable("Proc_SelectAllCards");
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
        [Route("api/CardController/SelectCardsByConsumerID")]
        [HttpGet]
        public IHttpActionResult SelectCardsByConsumerID(int ConsumerID)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add(nameof(ConsumerID), ConsumerID);
                DataTable result = Database.Database.ReadTable("Proc_SelectCardsByConsumerID", param);
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
                param.Add(nameof(card.CardNumber), card.CardNumber);
                param.Add(nameof(card.CardImage), card.CardImage);
                param.Add(nameof(card.CardExpiryDate), card.CardExpiryDate);
                param.Add(nameof(card.CardBalance), card.CardBalance);
                param.Add(nameof(card.CardTypeID), card.CardTypeID);
                param.Add(nameof(card.ConsumerID), card.ConsumerID);
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
                param.Add(nameof(card.CardID), card.CardID);
                param.Add(nameof(card.CardNumber), card.CardNumber);
                param.Add(nameof(card.CardImage), card.CardImage);
                param.Add(nameof(card.CardExpiryDate), card.CardExpiryDate);
                param.Add(nameof(card.CardBalance), card.CardBalance);
                param.Add(nameof(card.CardTypeID), card.CardTypeID);
                param.Add(nameof(card.ConsumerID), card.ConsumerID);
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
                param.Add(nameof(CardID), CardID);
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
