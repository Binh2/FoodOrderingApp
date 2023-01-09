using FoodOrderingApp.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingApp.Model
{
    class WebAPI
    {
        static private List<PropertyInfo> GetPropertyInfos<T>(string operationType)
        {
            if (!OperationType.isValidOperationType(operationType)) throw new ArgumentException("operationType can only be Insert or Update or Delete or Select");
            List<PropertyInfo> propertyInfos = new List<PropertyInfo>();
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                foreach (Attribute attribute in Attribute.GetCustomAttributes(typeof(T)))
                {
                    if (attribute is OperationType && ((OperationType)attribute).Type == operationType)
                    {
                        propertyInfos.Add(prop);
                    }
                }
            }
            return propertyInfos;
        }
        static async public Task<List<T>> GetAll<T>() where T : IBase, new()
        {
            T t = new T();
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/GetAll?pluralTable=" + t.pluralTable;
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(url);
            var resultConverted = JsonConvert.DeserializeObject<List<T>>(result);
            return resultConverted;
        }
        static async public Task<List<T>> GetBy<T>(string byColumn, object byValue) where T : IBase, new()
        {
            T t = new T();
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/GetBy?pluralTable=" + t.pluralTable + "&byColumn=" + byColumn +
                "&byValue='" + byValue.ToString() + "'";
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(url);
            var resultConverted = JsonConvert.DeserializeObject<List<T>>(result);
            return resultConverted;
        }
        static async public Task<string> Insert<T>(T obj) where T : IBase
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string uniqueValue = "0";

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (obj.parameterColumns.Contains(prop.Name))
                {
                    parameters.Add(prop.Name, prop.GetValue(obj));
                }
                if (obj.parameterColumns.Contains(obj.uniqueColumn))
                {
                    uniqueValue = prop.GetValue(obj).ToString();
                }
            }
            string parameterColumns = "";
            string parameterValues = "";
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                parameterColumns += (pair.Key + ",");
                parameterValues += ("'" + pair.Value.ToString() + "',");
            }
            parameterColumns = parameterColumns.Substring(0, parameterColumns.Length - 1);
            parameterValues = parameterValues.Substring(0, parameterValues.Length - 1);

            string url = "http://" + Constants.IP + "/webapi/api/BaseController/Insert?pluralTable=" + obj.pluralTable + "&parameterColumns=" + parameterColumns +
                "&parameterValues=" + parameterValues + "&uniqueColumn=" + obj.uniqueColumn + "&uniqueValue='"+ uniqueValue + "'";

            HttpClient http = new HttpClient();
            HttpResponseMessage result = await http.PostAsync(url, new StringContent(""));
            var resultString = await result.Content.ReadAsStringAsync();
            var resultConverted = JsonConvert.DeserializeObject<string>(resultString);
            return resultConverted;
        }
        static async public Task<int> Update<T>(T obj) where T : IBase
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string IDValue = "0";

            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                if (obj.parameterColumns.Contains(prop.Name) || prop.Name == obj.IDColumn)
                {
                    parameters.Add(prop.Name, prop.GetValue(obj));
                }
                if (obj.parameterColumns.Contains(obj.IDColumn))
                {
                    IDValue = prop.GetValue(obj).ToString();
                }
            }
            string param = "";
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                param += (pair.Key + "='" + pair.Value.ToString() + "',");
            }
            param = param.Substring(0, param.Length - 1);
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/Update?pluralTable=" + obj.pluralTable + "&parameters=" + param + 
                "&IDColumn=" + obj.IDColumn + "&IDValue='" + IDValue + "'";

            HttpClient http = new HttpClient();
            HttpResponseMessage result = await http.PostAsync(url, new StringContent(""));
            var resultString = await result.Content.ReadAsStringAsync();
            var resultConverted = JsonConvert.DeserializeObject<int>(resultString);
            return resultConverted;
        }
        static async public Task<string> Delete<T>(int id) where T: IBase, new()
        {
            T t = new T();
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/Delete?pluralTable=" + t.pluralTable + "&IDColumn=" + t.IDColumn + "&IDValue=" +
                id.ToString();
            HttpClient http = new HttpClient();
            HttpResponseMessage result = await http.PostAsync(url, new StringContent(""));
            var resultString = await result.Content.ReadAsStringAsync();
            var resultConverted = JsonConvert.DeserializeObject<string>(resultString);
            return resultConverted;
        }
        static async public Task<string> Post<T>(string proc)
        {
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/Post?proc=" + proc;
            HttpClient http = new HttpClient();
            HttpResponseMessage result = await http.PostAsync(url, new StringContent(""));
            var resultString = await result.Content.ReadAsStringAsync();
            var resultConverted = JsonConvert.DeserializeObject<string>(resultString);
            return resultConverted;
        }
        static async public Task<List<T>> Get<T>(string proc)
        {
            string url = "http://" + Constants.IP + "/webapi/api/BaseController/Get?proc=" + proc;
            HttpClient http = new HttpClient();
            var result = await http.GetStringAsync(url);
            var resultConverted = JsonConvert.DeserializeObject<List<T>>(result);
            return resultConverted;
        }
    }
}
