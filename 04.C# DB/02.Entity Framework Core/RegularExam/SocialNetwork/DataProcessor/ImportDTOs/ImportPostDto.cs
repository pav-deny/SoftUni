using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    public class ImportPostDto
    {
        [JsonProperty("Content")]
        [Required]
        [Length(5, 300)]
        public string Content { get; set; }

        [JsonProperty("CreatedAt")]
        [Required]
        public string CreatedAt { get; set; }

        [JsonProperty("CreatorId")]
        public int CreatorId { get; set; }//TO DO:Check if needs to be required
    }
}
