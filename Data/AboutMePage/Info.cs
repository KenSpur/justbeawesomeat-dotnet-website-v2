using System.Text.Json.Serialization;

namespace Data.AboutMePage
{
    public class Info
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonPropertyName("residence")]
        public string Residence { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("availability")]
        public string Availability { get; set; }
    }
}