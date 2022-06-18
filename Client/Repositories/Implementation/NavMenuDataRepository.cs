using Data.MainPage;
using System.Net.Http.Json;

namespace Client.Repositories.Implementation;

public class NavMenuDataRepository : IMainPageDataRepository
{
    private readonly HttpClient _httpClient;

    public NavMenuDataRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MainPageData> GetMainPageDataAsync()
        => await _httpClient.GetFromJsonAsync<MainPageData>("api/mainpage");
}