using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.ResumePage
{
    public class ResumePageData : IPageData
    {
        [JsonPropertyName("years_of_experience")]
        public int YearsOfExperience { get; set; }
        [JsonPropertyName("certifications")]
        public ICollection<Certification> Certifications { get; set; } = new List<Certification>();
        [JsonPropertyName("experiences")]
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        [JsonPropertyName("skills_collection")]
        public ICollection<Skills> SkillsCollection { get; set; } = new List<Skills>();
        [JsonPropertyName("industry_knowledge")]
        public ICollection<string> IndustryKnowledge { get; set; } = new List<string>();
    }
}