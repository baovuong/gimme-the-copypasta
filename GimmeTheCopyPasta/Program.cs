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
            

            var secret = config["secret"];
            var appId = config["appId"];

            var reddit = new RedditAPI(appId: appId, appSecret: secret);

            var results = reddit.Subreddit("copypasta").Posts.Best;
            foreach (var result in results)
            {
                Console.WriteLine(result.Title);
            }
        }
    }
}
