using Client.Repositories;
using Client.Repositories.Implementation;
using Client.Services;
using Client.Services.Implementation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");

builder.Services.AddScoped<INavigationService, NavigationService>();

builder.Services.AddHttpClient("Api", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));

builder.Services.AddTransient<IMainPageDataRepository, NavMenuDataRepository>();
builder.Services.AddTransient<IIndexPageDataRepository, IndexPageDataRepository>();
builder.Services.AddTransient<IAboutMePageDataRepository, AboutMePageDataRepository>();
builder.Services.AddTransient<IResumePageDataRepository, ResumePageDataRepository>();
builder.Services.AddTransient<IContactPageDataRepository, ContactPageDataRepository>();

await builder.Build().RunAsync();