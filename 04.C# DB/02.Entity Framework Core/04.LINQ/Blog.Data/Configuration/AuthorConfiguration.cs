using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Blog.Data.Models;

namespace Blog.Data.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            List<Author> authors = new()
            {
                new Author()
                {
                    Id = 1,
                    Name = "Jhon Doe"
                }
            };

            builder.HasData(authors);
        }
    }
}
