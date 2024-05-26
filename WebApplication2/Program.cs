using AbaceriaLolo.Backend.Business.Services;
using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AbaceriaLolo.Backend.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;
using AbaceriaLolo.Backend.Infrastructure.Data.Context;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder => builder.WithOrigins("http://localhost:4200")
//            .AllowAnyMethod()
//            .AllowCredentials()
//            .AllowAnyHeader());

//    //options.AddPolicy("AllowSpecificDeployOrigin",
//    //    builder => builder.WithOrigins("https://abaceria-lolo.web.app/")
//    //        .AllowAnyMethod()
//    //        .AllowCredentials()
//    //        .AllowAnyHeader());
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });


// SCOPES
// Los scopes son una forma de limitar la duración de un objeto que se crea en el contenedor de dependencias. 
// Cuando se crea un objeto en un scope, solo está disponible en ese scope y en los scopes secundarios.
// AddScoped: Crea un nuevo objeto para cada solicitud HTTP.


// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAllergenRepository, AllergenRepository>();
builder.Services.AddScoped<IMenuProductRepository, MenuProductRepository>();
builder.Services.AddScoped<IMenuSectionRepository, MenuSectionRepository>();
builder.Services.AddScoped<ITypeOfServingRepository, TypeOfServingRepository>();
builder.Services.AddScoped<IAllergenMenuProductRepository, AllergenMenuProductRepository>();
builder.Services.AddScoped<IMenuProductPriceRepository, MenuProductPriceRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAllergenService, AllergenService>();
builder.Services.AddScoped<IMenuProductService, MenuProductService>();
builder.Services.AddScoped<IMenuSectionService, MenuSectionService>();
builder.Services.AddScoped<ITypeOfServingService, TypeOfServingService>();
builder.Services.AddScoped<IAllergenMenuProductService, AllergenMenuProductService>();
builder.Services.AddScoped<IMenuProductPriceService, MenuProductPriceService>();

// Add DbContext
// Se agrega el contexto de la base de datos a la aplicación.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "AbaceriaLolo API",
        Description = "AbaceriaLolo API"
    });
});


// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);



var app = builder.Build();

// Configuración del pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AbaceriaLolo API v1");
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AbaceriaLolo API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy"); // Usar la política CORS definida
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();