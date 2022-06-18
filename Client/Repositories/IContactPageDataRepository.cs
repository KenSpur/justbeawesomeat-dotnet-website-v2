using Data.ContactPage;

namespace Client.Repositories;

public interface IContactPageDataRepository
{
    Task<ContactPageData> GetContactPageDataAsync();
    Task AddMessageAsync(Message message);
}