using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    [XmlRoot("Users")]
    public class ExportUsersWrapperDto
    {
        [XmlElement("User")]
        public List<ExportUserDto> Users { get; set; } = new List<ExportUserDto>();
    }
}
