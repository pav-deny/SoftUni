using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlAttribute("Friendships")]
        public int Friendships { get; set; }

        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlArray("Posts")]
        [XmlArrayItem("Post")]
        public List<ExportPostDto> Posts { get; set; } = new List<ExportPostDto>();
    }
}
