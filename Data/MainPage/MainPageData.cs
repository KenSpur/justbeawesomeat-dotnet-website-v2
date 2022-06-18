using System.Text.Json.Serialization;

namespace Data.MainPage
{
    public class MainPageData : IPageData
    {
        [JsonPropertyName("nav_menu_details")]
        public NavMenuDetails NavMenuDetails { get; set; } = new NavMenuDetails();
    }
}