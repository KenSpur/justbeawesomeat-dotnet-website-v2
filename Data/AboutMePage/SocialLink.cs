using System.Text.Json.Serialization;

namespace Data.AboutMePage
{
    public class SocialLink
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("icon_class")]
        public string IconClass { get; set; }
    }
}