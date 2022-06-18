using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.ContactPage
{
    public class Message
    {
        [Required(ErrorMessage = "Name is required.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Valid email is required.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please, leave me a message.")]
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}