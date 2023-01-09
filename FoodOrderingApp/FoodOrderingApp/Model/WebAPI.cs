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
            var result = await http.GetStringAsync(Constants.ProcURL.SELECT_ALL_CONSUMERS);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            return consumers;
        }
        static public async Task<Consumer> SelectConsumerByUsername(string ConsumerUsername)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(Constants.ProcURL.SELECT_CONSUMER_BY_USERNAME + "?ConsumerUsername=" + ConsumerUsername);
            var consumers = JsonConvert.DeserializeObject<List<Consumer>>(result);
            if (consumers.Count > 0) 
                return consumers[0];
            return null;
        }
        static public async Task<Consumer> SelectConsumerByEmail(string ConsumerEmail)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(Constants.ProcURL.SELECT_CONSUMER_BY_EMAIL + "?ConsumerEmail=" + ConsumerEmail);
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
            var reponse = await http.PostAsync(Constants.ProcURL.INSERT_CONSUMER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }
        static public async Task<int> UpdateConsumer(Consumer consumer)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(consumer);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await http.PostAsync(Constants.ProcURL.UPDATE_CONSUMER, stringContent);
            var resultString = await reponse.Content.ReadAsStringAsync();
            return int.Parse(resultString.ToString());
        }


    }
}
