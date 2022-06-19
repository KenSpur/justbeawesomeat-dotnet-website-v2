using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.ContactPage;
using Api.Services;

namespace Api;

public class ContactPageFunction
{
    private readonly IStorageService _storageService;

    public ContactPageFunction(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [FunctionName(nameof(ContactPageFunction))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "contactpage")] HttpRequest req)
        => new OkObjectResult(await _storageService.GetDataAsync<ContactPageData>());
}