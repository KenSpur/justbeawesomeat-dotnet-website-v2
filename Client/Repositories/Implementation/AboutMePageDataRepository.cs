using Data.AboutMePage;
using System.Net.Http.Json;

namespace Client.Repositories.Implementation;

public class AboutMePageDataRepository : IAboutMePageDataRepository
{
    private readonly HttpClient _httpClient;

    public AboutMePageDataRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AboutMePageData> GetAboutMePageDataAsync()
        => await _httpClient.GetFromJsonAsync<AboutMePageData>("api/aboutmepage");
}