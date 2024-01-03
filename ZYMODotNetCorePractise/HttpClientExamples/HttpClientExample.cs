using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYMODotNetCorePractise.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PKHDotNetCore.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        private HttpClient _client = new HttpClient();
        private string _blogUrl = "http://localhost:5042/api/Blog";

        public async Task Run()
        {
            // await Read();
            // await Edit(1);
            // await Edit(100);
            // await Create("Testing Title", "Mg Mg", "Tesing content body");
            // await Delete(11);
            await Update(1, "Testing Title", "Mg Mg", "Tesing content body");
            await Update(3, "Testing Title 2");
        }

        private async Task Read()
        {
            var response = await _client.GetAsync(_blogUrl);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                List<BlogDataModel> blogs = JsonConvert.DeserializeObject<List<BlogDataModel>>(result)!;
                foreach (var item in blogs)
                {
                    Console.WriteLine($"{item.Blog_Id} {item.Blog_Title} {item.Blog_Author} {item.Blog_Content}");
                }
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task Edit(int id)
        {
            var response = await _client.GetAsync($"{_blogUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(result)!;
                Console.WriteLine($"{item.Blog_Id} {item.Blog_Title} {item.Blog_Author} {item.Blog_Content}");
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task Create(string title, string author, string content)
        {
            var response = await _client.PostAsync(_blogUrl, new StringContent(JsonConvert.SerializeObject(new BlogDataModel { Blog_Title = title, Blog_Author = author, Blog_Content = content }), Encoding.UTF8, Application.Json));
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        private async Task Delete(int id)
        {
            var response = await _client.DeleteAsync($"{_blogUrl}/{id}");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        // PUT update
        private async Task Update(int id, string title, string author, string content)
        {
            var response = await _client.PutAsync($"{_blogUrl}/{id}", new StringContent(JsonConvert.SerializeObject(new BlogDataModel { Blog_Title = title, Blog_Author = author, Blog_Content = content }), Encoding.UTF8, Application.Json));
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        // PATCH update
        private async Task Update(int id, string title)
        {
            var response = await _client.PatchAsync($"{_blogUrl}/{id}", new StringContent(JsonConvert.SerializeObject(new BlogDataModel { Blog_Title = title }), Encoding.UTF8, Application.Json));
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}