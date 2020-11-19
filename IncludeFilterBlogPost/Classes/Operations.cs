using System;
using System.Linq;
using IncludeFilter.Context;
using Microsoft.EntityFrameworkCore;

namespace IncludeFilter
{
    public class Operations
    {
        /// <summary>
        /// Perform a filtered include
        /// </summary>
        /// <param name="token">value to filter on post title</param>
        public static void FilterPost(string token)
        {
            var originalForeColor = Console.ForegroundColor;

            using var context = new DatabasefirstBloggingContext();

            var blogs = context.Blogs
                .Include(blog => blog.Posts.Where(post => post.Title.Contains(token)))
                .ToList();

            foreach (var blog in blogs)
            {
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(blog);
                Console.ForegroundColor = originalForeColor;

                foreach (var blogPost in blog.Posts)
                {
                    Console.WriteLine($"   ID: {blogPost.PostId} Title: {blogPost.Title}");
                }
            }
        }
    }
}
