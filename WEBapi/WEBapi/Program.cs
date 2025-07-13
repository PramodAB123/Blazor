using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WEBapi
{
    public class Program
    {
        static void Main(string[] args)
        {
            var postdata = new PostData
            {
                Name = "joe",
                Age = 16,
                Address = "hello"
            };
            var client =new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            var json = JsonSerializer.Serialize(postdata);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("posts", content).Result;
            //Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var pdata = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(pdata);
            }
        }
    }
}
