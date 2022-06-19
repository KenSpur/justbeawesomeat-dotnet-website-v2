using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Api.Services;
using Api.Services.Implementations;
using Api.Options;
using System.IO;
using System.Reflection;

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

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        FunctionsHostBuilderContext context = builder.GetContext();

        builder.ConfigurationBuilder
            .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true, reloadOnChange: false)
            .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
            .AddEnvironmentVariables();
    }
}
