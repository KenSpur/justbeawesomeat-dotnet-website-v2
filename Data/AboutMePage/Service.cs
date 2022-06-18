using System.Text.Json.Serialization;

namespace Data.AboutMePage
{
    public class Service
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("icon_class")]
        public string IconClass { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}