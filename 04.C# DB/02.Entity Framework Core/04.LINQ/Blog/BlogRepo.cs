using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blog
{
    public class BlogRepo
    {
        private readonly Data.BlogDbContext context;

        public BlogRepo()
        {
            context = new Data.BlogDbContext();
        }

        public IQueryable<Post> GetPosts()
        {
            return context.Posts;
        }

        public IQueryable<Post> GetPostsWrong(Func<Post, bool> filter)
        {
            return context.Posts
                .TagWith("WRONG")
                .Where(filter)
                .AsQueryable();
        }

        public IQueryable<Post> GetPostsRight(Expression<Func<Post, bool>> filter)
        {
            return context.Posts
                .TagWith("RIGHT")
                .Where(filter)
                .AsQueryable();
        }
    }
}