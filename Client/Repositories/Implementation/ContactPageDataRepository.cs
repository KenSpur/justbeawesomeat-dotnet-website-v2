using Data.ContactPage;
using System.Net.Http.Json;

namespace Client.Repositories.Implementation;

public class ContactPageDataRepository : IContactPageDataRepository
{
    private readonly HttpClient _httpClient;

    public ContactPageDataRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ContactPageData> GetContactPageDataAsync()
        => await _httpClient.GetFromJsonAsync<ContactPageData>("api/contactpage");

    public async Task AddMessageAsync(Message message)
        => await _httpClient.PostAsJsonAsync("api/contactmessage", message);
}