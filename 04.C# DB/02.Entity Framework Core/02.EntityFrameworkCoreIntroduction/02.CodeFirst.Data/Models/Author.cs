using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02.CodeFirst.Data.Models
{
    [Table("Authors")]
    [Comment("Represents the author of a post")]
    public class Author
    {
        [Key]
        [Comment("The id of the author - primary key")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Unicode(true)]
        [Comment("The name of the author - required, maximum of 50 and supports unicode")]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}