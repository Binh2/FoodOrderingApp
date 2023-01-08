using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Model
{
    class WebAPI
    {
        static async public Task<T> GetAll<T>() where T : IBase, new()
        {
            T t = new T();
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/GetAll?pluralTable=" + t.pluralTable;
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(url);
            var resultConverted = JsonConvert.DeserializeObject<T>(result);
            return resultConverted;
        }
        static async public Task<T> GetBy<T>() where T : IBase, new()
        {
            T t = new T();
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/GetBy?pluralTable=" + t.pluralTable + "&byColumn=" + t.byColumn +
                "&byValue='" + t.byValue.ToString() + "'";
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(url);
            var resultConverted = JsonConvert.DeserializeObject<T>(result);
            return resultConverted;
        }
        //static async public Task<T> Insert<T>(T obj) where T : IBase
        //{
        //    string parameterColumns = typeof(T).GetProperties().Aggregate("", (columns, column) => columns ;
        //    string url = "http://" + Constants.IP + "/webapi/api/BaseController/Insert?pluralTable=" + obj.pluralTable + "&parameterColumns=" 
        //    HttpClient http = new HttpClient();
        //    string json = JsonConvert.SerializeObject(obj);
        //    StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        //    HttpResponseMessage result = await http.PostAsync(url, stringContent);
        //    var resultString = await result.Content.ReadAsStringAsync();
        //    var resultConverted = JsonConvert.DeserializeObject<T>(resultString);
        //    return resultConverted;
        //}
        //static async public Task<T> Update<T>(string url, object obj) // Not done
        //{
        //    HttpClient http = new HttpClient();
        //    string json = JsonConvert.SerializeObject(obj);
        //    StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        //    HttpResponseMessage result = await http.PostAsync(url, stringContent);
        //    var resultString = await result.Content.ReadAsStringAsync();
        //    var resultConverted = JsonConvert.DeserializeObject<T>(resultString);
        //    return resultConverted;
        //}
        static async public Task<T> Delete<T>(object obj) where T: IBase, new()
        {
            T t = new T();
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/Delete?pluralTable=" + t.pluralTable + "&tableID=" + t.byColumn + "&tableIDValue=" +
                t.byValue.ToString();
            HttpClient http = new HttpClient();
            string json = JsonConvert.SerializeObject(obj);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage result = await http.PostAsync(url, stringContent);
            var resultString = await result.Content.ReadAsStringAsync();
            var resultConverted = JsonConvert.DeserializeObject<T>(resultString);
            return resultConverted;
        }
        //static async public Task<T> Post<T>(string url, object obj)
        //{
        //    HttpClient http = new HttpClient();
        //    string json = JsonConvert.SerializeObject(obj);
        //    StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
        //    HttpResponseMessage result = await http.PostAsync(url, stringContent);
        //    var resultString = await result.Content.ReadAsStringAsync();
        //    var resultConverted = JsonConvert.DeserializeObject<T>(resultString);
        //    return resultConverted;
        //}
    }
}
