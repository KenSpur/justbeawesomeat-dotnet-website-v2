using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.ResumePage
{
    public class Experience
    {
        [JsonPropertyName("period")]
        public string Period { get; set; }
        [JsonPropertyName("client")]
        public string Client { get; set; }
        [JsonPropertyName("sector")]
        public string Sector { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("tasks")]
        public ICollection<string> Tasks { get; set; } = new List<string>();
        [JsonPropertyName("tags")]
        public ICollection<string> Tags { get; set; } = new List<string>();
    }
}