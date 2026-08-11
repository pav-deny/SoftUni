using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataProcessor.ExportDTOs
{
    public class ExportMessageDto
    {
        [JsonProperty("Content")]
        public string Content { get; set; }

        [JsonProperty("SentAt")]
        public string SentAt { get; set; }

        [JsonProperty("Status")]
        public int Status { get; set; }

        [JsonProperty("SenderUsername")]
        public string SenderUsername { get; set; }
    }
}
