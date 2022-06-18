using System.Text.Json.Serialization;

namespace Data.IndexPage
{
    public class IndexPageData : IPageData
    {
        [JsonPropertyName("title")]
        public Title Title { get; set; } = new Title();
    }
}