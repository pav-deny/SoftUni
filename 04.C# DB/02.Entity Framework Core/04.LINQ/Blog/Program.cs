using Blog;
using Blog.Data;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //using BlogDbContext context = new BlogDbContext();

            //List<ICollection<Reply>> replies = await context.Posts
            //    .Select(p => p.Replies)
            //    .ToListAsync();

            //List<Reply> repliesMany = await context.Posts
            //    .SelectMany(p => p.Replies)
            //    .ToListAsync();

            //var repliesMoreMany = await context.Posts
            //    .SelectMany(p => p.Replies,
            //    (p, r) => new
            //    {
            //        PostTitle = p.Title,
            //        ReplyTitle = r.Title,
            //        ReplyContent = r.Content
            //    })
            //    .ToListAsync();

            //BlogRepo repo = new BlogRepo();

            //List<Post> postsWrong = repo.GetPostsWrong(p => p.Title.Contains("First")).ToList();
            //var postsRight = repo.GetPostsRight(p => p.Title.Contains("First")).ToList();


        }
    }
}