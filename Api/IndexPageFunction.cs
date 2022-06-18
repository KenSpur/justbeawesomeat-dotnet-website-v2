using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.IndexPage;
using Api.Services;

namespace Api;

public class IndexPageFunction
{
    private readonly IStorageService _storageService;

    public IndexPageFunction(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "indexpage")] HttpRequest req)
        => new OkObjectResult(await _storageService.GetDataAsync<IndexPageData>());
}