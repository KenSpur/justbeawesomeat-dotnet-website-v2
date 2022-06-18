using System.Text.Json.Serialization;

namespace Data.AboutMePage
{
    public class Testimonial
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("image_source")]
        public string ImageSource { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("firm")]
        public string Firm { get; set; }
    }
}