using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Length(5, 300)]
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public int CreatorId { get; set; }

        public User Creator { get; set; }
    }
}
