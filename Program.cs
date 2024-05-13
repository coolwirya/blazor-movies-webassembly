using BlazorMovie.BlazorWebAssemblyStandaloneApp;
using BlazorMovie.BlazorWebAssemblyStandaloneApp.Components;
using BlazorMovie.BlazorWebAssemblyStandaloneApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TMDBClient>();

await builder.Build().RunAsync();
