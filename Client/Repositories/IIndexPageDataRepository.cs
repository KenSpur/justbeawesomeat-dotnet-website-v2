using Data.IndexPage;

namespace Client.Repositories;

public interface IIndexPageDataRepository
{
    Task<IndexPageData> GetIndexPageDataAsync();
}