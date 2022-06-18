using System.Text.Json.Serialization;

namespace Data.ContactPage
{
    public class Info
    {
        [JsonPropertyName("icon_class")]
        public string IconClass { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}