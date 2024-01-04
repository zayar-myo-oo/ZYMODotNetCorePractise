﻿using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZYMODotNetCorePractise.Models;

namespace AKLMPSTYZDotNetCore.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly IBlogApi _blogApi = RestService.For<IBlogApi>("https://localhost:7185");

        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(15);
            //await Create("Test Title", "Test Author", "Test Content");
            //await Update(28, "Title", "Test Author", "Test Content");
            await Delete(12);
        }

        public async Task Read()
        {
            var lst = await _blogApi.GetBlogs();
            foreach (BlogDataModel item in lst)
            {
                Console.WriteLine(item.Blog_Id);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Content);
            }
        }

        public async Task Edit(int id)
        {
            try
            {
                var item = await _blogApi.GetBlog(id);
                Console.WriteLine(item.Blog_Id);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Content);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.ReasonPhrase!.ToString());
                Console.WriteLine(ex.Content!.ToString());
            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
        }

        public async Task Create(string title, string author, string content)
        {
            var message = await _blogApi.CreateBlog(new BlogDataModel
            {
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            });
            await Console.Out.WriteLineAsync(message);
        }

        private async Task Update(int id, string title, string author, string content)
        {
            var message = await _blogApi.UpdateBlog(id, new BlogDataModel
            {
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            });
            await Console.Out.WriteLineAsync(message);
        }

        private async Task Delete(int id)
        {
            var message = await _blogApi.DeleteBlog(id);
            await Console.Out.WriteLineAsync(message);
        }
    }
}