using Data;
using System.Threading.Tasks;

namespace Api.Services;

public interface IStorageService
{
    Task<T> GetDataAsync<T>() where T : IPageData;
}