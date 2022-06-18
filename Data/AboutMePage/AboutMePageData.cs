using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.AboutMePage
{
    public class AboutMePageData : IPageData
    {
        [JsonPropertyName("keywords")]
        public string Keywords { get; set; }
        [JsonPropertyName("image_source")]
        public string ImageSource { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("future_ambitions")]
        public string FutureAmbitions { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; } = new Info();
        [JsonPropertyName("social_links")]
        public ICollection<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
        [JsonPropertyName("services")]
        public ICollection<Service> Services { get; set; } = new List<Service>();
        [JsonPropertyName("testimonials")]
        public ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
        [JsonPropertyName("fun_facts")]
        public ICollection<FunFact> FunFacts { get; set; } = new List<FunFact>();
    }
}