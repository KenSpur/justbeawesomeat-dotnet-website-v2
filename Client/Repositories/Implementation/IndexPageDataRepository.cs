using Data.IndexPage;
using System.Net.Http.Json;

namespace Client.Repositories.Implementation;

public class IndexPageDataRepository : IIndexPageDataRepository
{
    private readonly HttpClient _httpClient;

    public IndexPageDataRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IndexPageData> GetIndexPageDataAsync()
        => await _httpClient.GetFromJsonAsync<IndexPageData>("data/IndexPageData.json");
}