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
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AbaceriaLolo.Backend.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddEndpointsApiExplorer();

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
builder.Services.AddScoped<IInventorySectionRepository, InventorySectionRepository>();
builder.Services.AddScoped<IInventoryProductRepository, InventoryProductRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAllergenService, AllergenService>();
builder.Services.AddScoped<IMenuProductService, MenuProductService>();
builder.Services.AddScoped<IMenuSectionService, MenuSectionService>();
builder.Services.AddScoped<ITypeOfServingService, TypeOfServingService>();
builder.Services.AddScoped<IAllergenMenuProductService, AllergenMenuProductService>();
builder.Services.AddScoped<IMenuProductPriceService, MenuProductPriceService>();
builder.Services.AddScoped<IInventorySectionService, InventorySectionService>();
builder.Services.AddScoped<IInventoryProductService, InventoryProductService>();
builder.Services.AddScoped<IPdfService, PdfService>();

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

// Configurar Firebase
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile("AppData/abaceria-lolo-firebase-adminsdk-z0we3-36d7780640.json") // Cambia la ruta al archivo JSON descargado
});

// Configurar autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/abaceria-lolo";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/abaceria-lolo",
            ValidateAudience = true,
            ValidAudience = "abaceria-lolo",
            ValidateLifetime = true
        };
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
app.UseAuthentication();    
app.UseAuthorization();
app.UseMiddleware<UserEnabledMiddleware>(); // Se añade el middleware de verificación de usuario habilitado en la aplicación
app.MapControllers();
app.Run();
