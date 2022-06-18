using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.ContactPage
{
    public class ContactPageData : IPageData
    {
        [JsonPropertyName("info")]
        public ICollection<Info> Info { get; set; } = new List<Info>();
    }
}