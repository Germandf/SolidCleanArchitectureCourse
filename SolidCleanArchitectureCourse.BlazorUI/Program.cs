using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SolidCleanArchitectureCourse.BlazorUI;
using SolidCleanArchitectureCourse.BlazorUI.Contracts;
using SolidCleanArchitectureCourse.BlazorUI.Services;
using SolidCleanArchitectureCourse.BlazorUI.Services.Base;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<IClient, Client>(x => x.BaseAddress = new Uri("https://localhost:7220"));
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
