using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Reddit;

namespace GimmeTheCopyPasta
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var appId = config["appId"];
            var secret = config["secret"];


            var reddit = new RedditAPI(appId);

            var subreddit = reddit.Subreddit("AskReddit").About();

            var results = subreddit.Posts.Top;
            foreach (var result in results)
            {
                Console.WriteLine(result.Title);
            }
        }
    }
}
