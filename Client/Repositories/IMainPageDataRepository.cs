using Data.MainPage;

namespace Client.Repositories;

public interface IMainPageDataRepository
{
    Task<MainPageData> GetMainPageDataAsync();
}