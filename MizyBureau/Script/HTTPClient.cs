using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MizyBureau.Script
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public abstract class SendItem
    {
        public int Id { get; set; }
        [NonSerialized] public string Json;
        [NonSerialized] public string Url;
    }

    public class SendUser : SendItem
    {
        public string email { get; set; }
        public string password { get; set; }

        public SendUser(User u)
        {
            email = u._email;
            password = u._password;
            Json = JsonConvert.SerializeObject(this);
            Url = "auth/user";
        }
    }

    public class SendNewUser : SendItem
    {
        public string email { get; set; }
        public string password { get; set; }

        public string lastname { get; set; }

        public string firstname { get; set; }

        public SendNewUser(User u)
        {
            email = u._email;
            password = u._password;
            firstname = u._firstname;
            lastname = u._lastname;
            Json = JsonConvert.SerializeObject(this);
            Url = "user";
        }
    }

    public class OverHttpClient
    {
        public static OverHttpClient instance;
        static HttpClient client = new HttpClient();

        public bool ShowDebug = true;

        public async Task<HttpContent> CreateSendItemAsync<T>(T SendItem) where T : SendItem
        {
            HttpResponseMessage response = await client.PostAsync(SendItem.Url, new StringContent(SendItem.Json, Encoding.UTF8, "application/json"));

            if (ShowDebug)
            {
                Console.WriteLine($"Json: {SendItem.Json}");
                Console.WriteLine($"response: {response}");
                Console.WriteLine($"responseContent: {response.Headers}");
            }

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch
            {
                return null;
            }

            // return URI of the created resource.
            //return response.Headers.Location;
            return response.Content;
        }

        static async Task<SendItem> GetSendItemAsync(string path)
        {
            SendItem SendItem = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string str = await response.Content.ReadAsStringAsync();
                //SendItem.Name = str;
            }
            return SendItem;
        }

        static async Task<SendItem> UpdateSendItemAsync(SendItem SendItem)
        {
            //HttpResponseMessage response = await client.PutAsync($"api/SendItems/{SendItem.Id}", SendItem);
           // response.EnsureSuccessStatusCode();

            // Deserialize the updated SendItem from the response body.
            //string str = await response.Content.ReadAsStringAsync();
            return SendItem;
        }

        static async Task<HttpStatusCode> DeleteSendItemAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/SendItems/{id}");
            return response.StatusCode;
        }
        public OverHttpClient()
        {
            instance = this;
            client.BaseAddress = new Uri("https://api.mizy.epac.se/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
