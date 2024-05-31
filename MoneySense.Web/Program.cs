using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MoneySense.Web;
using MudBlazor.Services;
using MoneySense.Core;
using MoneySense.Core.Handler;
using MoneySense.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudBlazor();

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

builder.Services.AddHttpClient("web", options => { options.BaseAddress = new Uri(Configuration.BackendUrl); });

await builder.Build().RunAsync();
