using BlazorAuth.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json.Linq;

namespace BlazorAuth.Controllers 
{
    public class ServiceHelper 
    {
        private static Uri DataBaseAddress {get; set;} = new Uri("http://localhost:5094");

        private static HttpClient GetClientData()
        {
            var clientData = new HttpClient();
            clientData.BaseAddress = DataBaseAddress;
            return clientData;
        }

         public async static Task<LoginHos> PostLogin(string username, string password)
        {
           var param = new Dictionary<string, string>();
           param.Add("uname", username);
           param.Add("para", password);

           var content = new FormUrlEncodedContent(param);

           var clientData = GetClientData();
           var response = await clientData.PostAsync("api/Hos/PostUser", content);
           if (response.StatusCode == System.Net.HttpStatusCode.OK)
           {
                var json = await response.Content.ReadAsStringAsync();
                return JObject.Parse(json).ToObject<LoginHos>();
           } 
           else return new LoginHos();
        }

    }
}