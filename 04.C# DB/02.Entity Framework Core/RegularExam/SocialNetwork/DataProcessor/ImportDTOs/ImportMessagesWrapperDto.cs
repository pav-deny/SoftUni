using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    [XmlType("Messages")]
    public class ImportMessagesWrapperDto
    {
        [XmlElement("Message")]
        public ImportMessageDto[] Messages { get; set; }
    }
}
