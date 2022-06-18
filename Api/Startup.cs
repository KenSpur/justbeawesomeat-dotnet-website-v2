using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Api.Services;
using Api.Services.Implementations;
using Api.Options;

[assembly: FunctionsStartup(typeof(Api.Startup))]

namespace Api;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddOptions<SendGridOptions>().Configure<IConfiguration>((options, configuration) => configuration
            .GetSection(SendGridOptions.Key).Bind(options));
        builder.Services.AddOptions<PageDataStorageOptions>().Configure<IConfiguration>((options, configuration) => configuration
            .GetSection(PageDataStorageOptions.Key).Bind(options));

        builder.Services.AddTransient<IStorageService, PageDataStorageService>();
    }
}
