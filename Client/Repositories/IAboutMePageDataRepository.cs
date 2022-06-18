using Data.AboutMePage;

namespace Client.Repositories;

public interface IAboutMePageDataRepository
{
    Task<AboutMePageData> GetAboutMePageDataAsync();
}