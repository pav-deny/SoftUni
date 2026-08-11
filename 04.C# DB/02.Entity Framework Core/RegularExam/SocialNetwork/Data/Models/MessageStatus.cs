using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Data.Models
{
    public enum MessageStatus
    {
        Sent = 0,
        Delivered,
        Seen,
        Failed
    }
}
