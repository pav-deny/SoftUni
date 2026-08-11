using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    [XmlType("Post")]
    public class ExportPostDto
    {
        [XmlElement("Content")]
        public string Content { get; set; }

        [XmlElement("CreatedAt")]
        public string CreatedAt { get; set; }
    }
}
