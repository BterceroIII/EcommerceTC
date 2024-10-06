using Ecommerce.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

using Ecommerce.Repository.Contract;
using Ecommerce.Repository.Implement;

using Ecommerce.Utilities;

using Ecommerce.Service.Contract;
using Ecommerce.Service.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// dependece

builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

// como es generica y no especifica el modelo que se utiliza AddTransient
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// se utiliza AddScoped cuando se especifica el modelo
builder.Services.AddScoped<ISaleRepository, SaleRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// SERVICES
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductoService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
