using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Data.Models
{
    [Comment("Represents a blog post")]
    [Index(nameof(Title))]
    //[PrimaryKey(nameof(PostId), nameof(Title))]
    public class Post
    {
        [Key]
        [Comment("The Id of the Post, also it's Primary Key")]
        public int PostId { get; set; }

        [Required]
        [MaxLength(200)]
        [Unicode(true)]
        [Comment("The title of the post - it is required, has a max length of 200 and supports unicode")]
        public string Title { get; set; } 

        [Required]
        [MaxLength(2000)]
        [Unicode(true)]
        [Comment("The content of the post - it is required, has a max length of 2 000 and supports unicode")]
        public string Content { get; set; }

        [Required]
        [Comment("The Id of the author - foreign key")]
        public int AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime UpdatedOn { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
