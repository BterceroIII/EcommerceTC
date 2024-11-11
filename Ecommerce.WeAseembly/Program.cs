using Ecommerce.WeAseembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;
using Blazored.Toast;

using Ecommerce.WeAseembly.Services.Contract;
using Ecommerce.WeAseembly.Services.Implement;

using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5245/api/") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
