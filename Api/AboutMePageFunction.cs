using Data.AboutMePage;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Services;

namespace Api;

public class AboutMePageFunction
{
    private readonly IStorageService _storageService;

    public AboutMePageFunction(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "aboutmepage")] HttpRequest req)
        => new OkObjectResult(await _storageService.GetDataAsync<AboutMePageData>());
}