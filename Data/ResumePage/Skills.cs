using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.ResumePage
{
    public class Skills
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("collection")]
        public ICollection<Skill> Collection { get; set; } = new List<Skill>();
    }
}