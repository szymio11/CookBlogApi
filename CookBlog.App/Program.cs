using Blazored.LocalStorage;
using CookBlog.App;
using CookBlog.App.Data;
using CookBlog.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient<ICategoryDataService, CategoryDataService>(client => client.BaseAddress = new Uri("https://localhost:5001/"));
builder.Services.AddHttpClient<ITagDataService, TagDataService>(client => client.BaseAddress = new Uri("https://localhost:5001/"));
builder.Services.AddHttpClient<IPostDataService, PostDataService>(client => client.BaseAddress = new Uri("https://localhost:5001/"));
builder.Services.AddHttpClient<IUserDataService, UserDataService>(client => client.BaseAddress = new Uri("https://localhost:5001/"));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());

await builder.Build().RunAsync();