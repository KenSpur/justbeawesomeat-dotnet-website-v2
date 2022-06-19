using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.MainPage;
using Api.Services;

namespace Api;

public class MainPageFunction
{
    private readonly IStorageService _storageService;

    public MainPageFunction(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [FunctionName(nameof(MainPageFunction))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "mainpage")] HttpRequest req)
        => new OkObjectResult(await _storageService.GetDataAsync<MainPageData>());
}