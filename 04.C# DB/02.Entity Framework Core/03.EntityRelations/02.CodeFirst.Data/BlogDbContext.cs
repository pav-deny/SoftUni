using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Blog.Data
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reply> Replies { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options) { }

        public BlogDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Author>(entity =>
            //{
            //    entity.ToTable("Users");
            //    entity.HasKey(a => a.Id);
            //    entity.Property(a => a.Id)
            //        .ValueGeneratedOnAdd() //Identity
            //        .HasComment("Primary key for the author");
            //    entity.Property(a => a.Name)
            //        .HasDefaultValue("Unknown author")
            //        .IsRequired()
            //        .IsUnicode(true)
            //        .HasMaxLength(100)
            //        .HasComment("The name of the author");
            //});

            modelBuilder.ApplyConfiguration(new Configuration.PostConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.ReplyConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DENI-PC\\SQLEXPRESS; Database=Blog; Integrated Security=true; TrustServerCertificate=true");
            }
        }


    }
}
