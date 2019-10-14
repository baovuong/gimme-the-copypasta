using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace GimmeTheCopyPasta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetRandomPost().Data.Selftext);
        }

        static Child GetRandomPost(string type = "top")
        {
            return GetPosts(type, 100).Data.Children
                .AsEnumerable()
                .Where(c => c.Data.Selftext.Length > 0)
                .RandomShuffle()
                .FirstOrDefault();
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
