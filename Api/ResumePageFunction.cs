using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.ResumePage;
using Api.Services;

namespace Api;

public class ResumePageFunction
{
    private readonly IStorageService _storageService;

    public ResumePageFunction(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "resumepage")] HttpRequest req)
        => new OkObjectResult(await _storageService.GetDataAsync<ResumePageData>());
}