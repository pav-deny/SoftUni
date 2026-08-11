using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [Length(2, 30)]
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartedAt { get; set; }

        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<UserConversation> UsersConversations { get; set; } = new List<UserConversation>();
    }
}
