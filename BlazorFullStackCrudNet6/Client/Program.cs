global using BlazorFullStackCrudNet6.Client.Services.SuperHeroService;
global using BlazorFullStackCrudNet6.Shared;

using BlazorFullStackCrudNet6.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>(); //register our new service
await builder.Build().RunAsync();
