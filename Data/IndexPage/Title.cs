using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.IndexPage
{
    public class Title
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("items")]
        public ICollection<string> Items { get; set; } = new List<string>();

        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";
    }
}