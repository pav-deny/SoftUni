using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Length(4, 20)]
        [Required]
        public string Username { get; set; }

        [Length(8, 60)]
        [Required]
        public string Email { get; set; }

        [MinLength(6)]
        [Required]
        public string Password { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Message> Messages { get; set; } = new List<Message>();

        public ICollection<UserConversation> UsersConversations { get; set; } = new List<UserConversation>();
    }
}
