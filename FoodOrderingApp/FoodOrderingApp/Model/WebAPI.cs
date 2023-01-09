using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Model
{
    class WebAPI
    {
        static public async Task<List<Consumer>> SelectAllConsumers()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_CONSUMERS);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            return consumers;
        }
        static public async Task<Consumer> SelectConsumerByUsername(string ConsumerUsername)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_CONSUMER_BY_USERNAME + "?ConsumerUsername=" + ConsumerUsername);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            if (consumers.Count > 0) 
                return consumers[0];
            return null;
        }
        static public async Task<Consumer> SelectConsumerByEmail(string ConsumerEmail)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_CONSUMER_BY_EMAIL + "?ConsumerEmail=" + ConsumerEmail);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            if (consumers.Count > 0) 
                return consumers[0];
            return null;
        }
        static public async Task<int> InsertConsumer(Consumer consumer)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(consumer);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_CONSUMER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateConsumer(Consumer consumer)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(consumer);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_CONSUMER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteConsumer(int ConsumerID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.UPDATE_CONSUMER + "?ConsumerID=" + ConsumerID.ToString(), new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }

        static public async Task<List<Card>> SelectAllCards()
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_CARDS);
            var cards = JsonConvert.DeserializeObject<List<Card>>(result);
            return cards;
        }
        static public async Task<List<Card>> SelectCardsByConsumerID(int ConsumerID)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(ProcURL.SELECT_ALL_CARDS + "?ConsumerID=" + ConsumerID);
            var cards = JsonConvert.DeserializeObject<List<Card>>(result);
            return cards;
        }
        static public async Task<int> InsertCard(Card card)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(card);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.INSERT_CARD, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateCard(Card card)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(card);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(ProcURL.UPDATE_CARD, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> DeleteCard(int CardID)
        {
            HttpClient http = new HttpClient();
            var reponse = await http.PostAsync(ProcURL.DELETE_CARD + "?CardID=" + CardID, new StringContent(""));
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
    }
    public static class ProcURL
    {
        public static readonly string SELECT_ALL_CARDS = "http://" + Constants.IP + "/webapi/api/CardController/SelectAllCards";
        public static readonly string INSERT_CARD = "http://" + Constants.IP + "/webapi/api/CardController/InsertCard";
        public static readonly string UPDATE_CARD = "http://" + Constants.IP + "/webapi/api/CardController/UpdateCard";
        public static readonly string DELETE_CARD = "http://" + Constants.IP + "/webapi/api/CardController/DeleteCard";

        public static readonly string SELECT_ALL_CONSUMERS = "http://" + Constants.IP + "/webapi/api/ConsumerController/SelectAllConsumers";
        public static readonly string SELECT_CONSUMER_BY_USERNAME = "http://" + Constants.IP + "/webapi/api/ConsumerController/SelectConsumerByUsername";
        public static readonly string SELECT_CONSUMER_BY_EMAIL = "http://" + Constants.IP + "/webapi/api/ConsumerController/SelectConsumerByEmail";
        public static readonly string INSERT_CONSUMER = "http://" + Constants.IP + "/webapi/api/ConsumerController/InsertConsumer";
        public static readonly string UPDATE_CONSUMER = "http://" + Constants.IP + "/webapi/api/ConsumerController/UpdateConsumer";
        public static readonly string DELETE_CONSUMER = "http://" + Constants.IP + "/webapi/api/ConsumerController/DeleteConsumer";
    }
}
