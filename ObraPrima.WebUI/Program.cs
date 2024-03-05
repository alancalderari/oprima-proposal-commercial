using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ObraPrima.WebUI;
using ObraPrima.WebUI.Providers;
using ObraPrima.WebUI.Services.Auth;
using ObraPrima.WebUI.Services.Contracts.Auth;
using ObraPrima.WebUI.Services.Contracts.Lead;
using ObraPrima.WebUI.Services.Lead;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddHttpClient("HttpClient", x =>
{
    x.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
}).AddHttpMessageHandler<CustomHttpHendler>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<ILeadService,LeadService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<CustomHttpHendler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddMudServices();
builder.Logging.ClearProviders();
await builder.Build().RunAsync();
