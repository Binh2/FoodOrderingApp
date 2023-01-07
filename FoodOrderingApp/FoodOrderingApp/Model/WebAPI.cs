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
        static async public Task<T> Get<T>(string url)
        {
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(url);
            var resultConverted = JsonConvert.DeserializeObject<T>(result);
            return resultConverted;
        }
        static async public Task<T> Post<T>(string url, object obj)
        {
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(obj);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await http.PostAsync(url, stringContent);
            var resultString = await result.Content.ReadAsStringAsync();
            var resultConverted = JsonConvert.DeserializeObject<T>(resultString);
            return resultConverted;
        }
    }
}
