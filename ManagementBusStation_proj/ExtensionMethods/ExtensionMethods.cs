using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace ManagementBusStation
{
    public static class ExtensionMethodsSerializationDeserialization
    {
        public static string SerializeToJson<T>(this T obj) where T : class
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });           
        }

        public static T DeserializeToObjectFromJson<T>(this string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    public static class ExtensionMethodsBase64Formatting
    {      
        public static string ConvertToBase64String(this string original)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(original);
            return Convert.ToBase64String(bytes);
        }

        public static string ConvertFromBase64String(this string base64)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(base64)); 
        }
    }    
}