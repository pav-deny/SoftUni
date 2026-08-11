using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(ConversationId))]
    public class UserConversation
    {
        [ForeignKey(nameof(User))]
        [Required]
        public int UserId { get; set; }
        
        public User User { get; set; }

        [ForeignKey(nameof(Conversation))]
        [Required]
        public int ConversationId { get; set; }

        public Conversation Conversation { get; set; }
    }
}
