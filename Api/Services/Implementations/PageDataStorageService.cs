using Data;
using Data.AboutMePage;
using Data.ContactPage;
using Data.IndexPage;
using Data.MainPage;
using Data.ResumePage;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Options;

namespace Api.Services.Implementations;

public class PageDataStorageService : IStorageService
{
    private readonly PageDataStorageOptions _options;

    public PageDataStorageService(IOptions<PageDataStorageOptions> options)
    {
        _options = options.Value;
    }

    public async Task<T> GetDataAsync<T>() where T : IPageData
    {
        var container = new BlobContainerClient(_options.ConnectionString, _options.WebsitePageDataContainer);
        var blob = container.GetBlobClient(GetBlobName<T>());

        var download = await blob.DownloadAsync();

        return await JsonSerializer.DeserializeAsync<T>(download.Value.Content);
    }

    private string GetBlobName<T>() where T : IPageData
    {
        if (typeof(T) == typeof(MainPageData)) return _options.MainPageDataBlob;
        if (typeof(T) == typeof(IndexPageData)) return _options.IndexPageDataBlob;
        if (typeof(T) == typeof(AboutMePageData)) return _options.AboutMePageDataBlob;
        if (typeof(T) == typeof(ResumePageData)) return _options.ResumePageDataBlob;
        if (typeof(T) == typeof(ContactPageData)) return _options.ContactPageDataBlob;

        throw new ArgumentOutOfRangeException();
    }
}