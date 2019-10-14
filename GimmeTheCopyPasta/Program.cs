using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace GimmeTheCopyPasta
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPosts("hot", 10).Data.Children
                .Select(c => c.Data.Selftext)
                .ToList()
                .ForEach(c => Console.WriteLine(c));
        }

        static Posts GetPosts(string type = "top", int limit = 100)
        {
            var client = new RestClient("https://www.reddit.com");

            var request = new RestRequest("r/copypasta/" + type + ".json", Method.GET);
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("t", "all");

            var response = client.Execute(request);

            return Posts.FromJson(response.Content);
        }
    }
}
