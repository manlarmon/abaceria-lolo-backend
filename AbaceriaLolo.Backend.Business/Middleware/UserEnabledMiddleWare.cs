using AbaceriaLolo.Backend.Infrastructure.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

public class UserEnabledMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<UserEnabledMiddleware> _logger;

    public UserEnabledMiddleware(RequestDelegate next, ILogger<UserEnabledMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, IUserService userService)
    {

        // Lo uso para ver los claim que tiene el usuario autenticado 
        // Un claim es un par clave-valor que representa un atributo del usuario
        // El httpContext es un objeto que encapsula toda la información específica de una solicitud HTTP.
        // Los claim vienen del token que se genera al autenticar el usuario.

        //if (context.User.Identity.IsAuthenticated)
        //{
        //    foreach (var claim in context.User.Claims)
        //    {
        //        _logger.LogInformation($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
        //        var claimType = claim.Type;
        //        var claimValue = claim.Value;                
        //    }
        //}

        if (context.User.Identity.IsAuthenticated)
        {
            var userEmailClaim = context.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            var isEnabled = await userService.IsUserEnabledAsync(userEmailClaim);
            if (!isEnabled)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("User is disabled.");
                return;
            }
        }

        await _next(context);
    }
}
