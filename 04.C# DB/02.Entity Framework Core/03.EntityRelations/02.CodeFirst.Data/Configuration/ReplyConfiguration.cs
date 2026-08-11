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
           builder.HasOne(r => r.Post)
                .WithMany(p => p.Replies)
                .HasForeignKey(r => r.PostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
