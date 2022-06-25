using System.Text.Json.Serialization;

namespace Data.MainPage
{
    public class NavMenuDetails
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonIgnore]
        public string FullName => $"{FirstName} {LastName}";
    }
}