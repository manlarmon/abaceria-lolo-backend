using AbaceriaLolo.Backend.Business.Services;
using AbaceriaLolo.Backend.Infrastructure.Data;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IRepositories;
using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using AbaceriaLolo.Backend.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
    });
});

// SCOPES
// Los scopes son una forma de limitar la duración de un objeto que se crea en el contenedor de dependencias. 
// Cuando se crea un objeto en un scope, solo está disponible en ese scope y en los scopes secundarios.
// AddScoped: Crea un nuevo objeto para cada solicitud HTTP.

builder.Services.AddScoped<IMenuSectionRepository, MenuSectionRepository>();
builder.Services.AddScoped<IMenuSectionService, MenuSectionService>();
builder.Services.AddScoped<IAllergenRepository, AllergenRepository>();
builder.Services.AddScoped<IAllergenService, AllergenService>();
builder.Services.AddScoped<IMenuProductRepository, MenuProductRepository>();
builder.Services.AddScoped<IMenuProductService, MenuProductService>();

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
app.UseCors("AllowSpecificOrigin");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();