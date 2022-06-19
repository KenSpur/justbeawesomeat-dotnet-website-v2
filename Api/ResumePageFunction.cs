using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.ResumePage;
using Api.Services;
using System.Text.Json;

namespace Api;

public class ResumePageFunction
{
    private readonly IStorageService _storageService;

    public ResumePageFunction(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [FunctionName(nameof(ResumePageFunction))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "resumepage")] HttpRequest req)
        => new OkObjectResult(JsonSerializer.Serialize(await _storageService.GetDataAsync<ResumePageData>()));
}