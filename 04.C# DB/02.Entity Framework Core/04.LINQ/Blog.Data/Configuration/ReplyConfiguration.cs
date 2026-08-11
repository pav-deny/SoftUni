using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Blog.Data.Configuration
{
    public class ReplyConfiguration : IEntityTypeConfiguration<Reply>
    {
        public void Configure(EntityTypeBuilder<Reply> builder)
        {
            List<Reply> replies = new List<Reply>()
            {
                new Reply()
                {
                    Id = 1,
                    Content = "Good one",
                    PostId = 1,
                    Title = "Idk"
                },

                new Reply()
                {
                    Id = 2,
                    Content = "Still good...",
                    PostId = 1,
                    Title = "Idk 2: Electric boogalo"
                },

                new Reply()
                {
                    Id = 3,
                    Content = "Cause why not",
                    PostId = 2,
                    Title = "Idk: The Spinoff"
                },

                new Reply()
                {
                    Id = 4,
                    Content = "Okay this is getting out of hand",
                    PostId = 2,
                    Title = "Idk: The Spinoff 2"
                }
            };


           builder.HasOne(r => r.Post)
                .WithMany(p => p.Replies)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(replies);
        }
    }
}
