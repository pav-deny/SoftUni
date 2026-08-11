using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Blog.Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    PostId = 1,
                    Title = "First Post",
                    AuthorId = 1,
                    Content = "idk man"
                },
                new Post()
                {
                    PostId = 2,
                    Title = "Second Post",
                    AuthorId = 1,
                    Content = "idk man, again"
                }
            };

            builder.Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.UpdatedOn)
                .ValueGeneratedOnAdd();

            builder.HasData(posts);
        }
    }
}
