using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Length(1, 200)]
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime SentAt { get; set; }

        [Required]
        public MessageStatus Status { get; set; }

        [ForeignKey(nameof(Conversation))]
        [Required]
        public int ConversationId { get; set; }

        public Conversation Conversation { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public int SenderId { get; set; }

        public User Sender { get; set; }
    }
}
