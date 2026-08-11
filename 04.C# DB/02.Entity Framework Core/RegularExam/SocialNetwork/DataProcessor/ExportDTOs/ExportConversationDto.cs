using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    public class ExportConversationDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("StartedAt")]
        public string StartedAt { get; set; }

        [JsonProperty("Messages")]
        public List<ExportMessageDto> Messages { get; set; } = new List<ExportMessageDto>();
    }
}
