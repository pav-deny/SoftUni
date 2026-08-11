using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Data.Models
{
    [Comment("A reply to a post")]
    public class Reply
    {
        [Key]
        [Comment("The id of the reply - primary key")]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Unicode(true)]
        [Comment("The tittle of the reply")]
        public required string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        [Unicode(true)]
        [Comment("The content of the reply - required, has a maximum of 1 000 and supports unicode")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("The id of the post - foreign key")]
        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }
}