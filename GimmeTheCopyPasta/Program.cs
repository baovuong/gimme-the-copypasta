using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using RedditSharp;
using RedditSharp.Things;

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

            var username = config["username"];
            var password = config["password"];

            var reddit = new Reddit();
            reddit.LogIn(username, password);
            var subreddit = reddit.GetSubreddit("copypasta");
            var posts = subreddit.GetTop(FromTime.All).OrderBy(a => Guid.NewGuid()).ToList();

            foreach (var post in posts.Take(20))
            {
                Console.WriteLine(post.Title);
            }
        }
    }
}
