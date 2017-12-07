using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MizyBureau.Script
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    namespace HttpClientSample
    {
        public class SendItem : HttpContent
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Message { get; set; }
            public string Date { get; set; }

            protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
            {
                throw new NotImplementedException();
            }

            protected override bool TryComputeLength(out long length)
            {
                throw new NotImplementedException();
            }
        }

        class Program
        {
            static HttpClient client = new HttpClient();

            static void ShowSendItem(SendItem SendItem)
            {
                Console.WriteLine($"Name: {SendItem.Name}\tPrice: {SendItem.Message}\tDate: {SendItem.Date}");
            }

            static async Task<Uri> CreateSendItemAsync(SendItem SendItem)
            {
                HttpResponseMessage response = await client.PostAsync("api/SendItems", SendItem);
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.
                return response.Headers.Location;
            }

            static async Task<SendItem> GetSendItemAsync(string path)
            {
                SendItem SendItem = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    string str = await response.Content.ReadAsStringAsync();
                    SendItem.Name = str;
                }
                return SendItem;
            }

            static async Task<SendItem> UpdateSendItemAsync(SendItem SendItem)
            {
                HttpResponseMessage response = await client.PutAsync($"api/SendItems/{SendItem.Id}", SendItem);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated SendItem from the response body.
                string str = await response.Content.ReadAsStringAsync();
                SendItem.Name = str;
                return SendItem;
            }

            static async Task<HttpStatusCode> DeleteSendItemAsync(string id)
            {
                HttpResponseMessage response = await client.DeleteAsync($"api/SendItems/{id}");
                return response.StatusCode;
            }

            static async Task RunAsync()
            {
                client.BaseAddress = new Uri("http://localhost:55268/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Create a new SendItem
                    SendItem SendItem = new SendItem { Name = "Gizmo", Message = 100, Date = "Widgets" };

                    var url = await CreateSendItemAsync(SendItem);
                    Console.WriteLine($"Created at {url}");

                    // Get the SendItem
                    SendItem = await GetSendItemAsync(url.PathAndQuery);
                    ShowSendItem(SendItem);

                    // Update the SendItem
                    Console.WriteLine("Updating price...");
                    SendItem.Message = 80;
                    await UpdateSendItemAsync(SendItem);

                    // Get the updated SendItem
                    SendItem = await GetSendItemAsync(url.PathAndQuery);
                    ShowSendItem(SendItem);

                    // Delete the SendItem
                    var statusCode = await DeleteSendItemAsync(SendItem.Id);
                    Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();
            }

        }
    }
}
