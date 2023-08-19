using CookBlog.App;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ICategoryDataService, CategoryDataService>(client => client.BaseAddress = new Uri("https://localhost:5001/"));
builder.Services.AddHttpClient<ITagDataService, TagDataService>(client => client.BaseAddress = new Uri("https://localhost:5001/"));
builder.Services.AddHttpClient<IPostDataService, PostDataService>(client => client.BaseAddress = new Uri("https://localhost:5001/"));
builder.Services.AddMudServices();

await builder.Build().RunAsync();
