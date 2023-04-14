using AutoMapper;
using BFF.API.Core.Service;
using BFF.API.Helpers;
using BFF.Models.Entities;
using BFF.Repositories;
using BFF.Services;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Product>("Products");
modelBuilder.EntitySet<Category>("Categories");

builder.Services.AddScoped<IBaseService<Product>, ProductService>();
builder.Services.AddScoped<IBaseService<Category>, CategoryService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();

builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddDbContext<BFF.Core.Data.DataContext>();

builder.Services.AddScoped<BFF.Core.Data.DataContext>();
builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BFF", Version = "v1" });
});
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<MapHelper>();
var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BFF V1");
    c.RoutePrefix = string.Empty;
});
app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();