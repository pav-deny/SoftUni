using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    [XmlType("Message")]
    public class ImportMessageDto
    {
        [XmlElement("Content")]
        [Required]
        [Length(1, 200)]
        public string Content { get; set; }

        [XmlAttribute("SentAt")]
        [Required]
        public string SentAt { get; set; }

        [XmlElement("Status")]
        [Required]
        public string Status { get; set; }

        [XmlElement("ConversationId")]
        public int ConversationId { get; set; }

        [XmlElement("SenderId")]
        public int SenderId { get; set; }
    }
}
