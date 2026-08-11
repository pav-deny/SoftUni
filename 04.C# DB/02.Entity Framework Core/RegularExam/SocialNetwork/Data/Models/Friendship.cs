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
    [PrimaryKey(nameof(UserOneId), nameof(UserTwoId))]
    public class Friendship
    {
        [ForeignKey(nameof(User))]
        [Required]
        public int UserOneId { get; set; }

        public User UserOne { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public int UserTwoId { get; set; }
        
        public User UserTwo { get; set; }
    }
}
