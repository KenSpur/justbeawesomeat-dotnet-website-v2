using System.Text.Json.Serialization;

namespace Data.ResumePage
{
    public class Skill
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("percentage")]
        public int Percentage { get; set; }
    }
}