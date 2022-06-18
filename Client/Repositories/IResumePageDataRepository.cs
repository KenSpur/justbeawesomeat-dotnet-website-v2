using Data.ResumePage;

namespace Client.Repositories;

public interface IResumePageDataRepository
{
    Task<ResumePageData> GetResumePageDataAsync();
}