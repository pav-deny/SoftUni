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
            builder.Property(p => p.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.UpdatedOn)
                .ValueGeneratedOnAdd();
        }
    }
}
