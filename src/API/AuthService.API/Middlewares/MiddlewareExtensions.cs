using Microsoft.AspNetCore.Builder;

namespace AuthService.API.Middlewares
{
    public static class MiddlewareExtensions
    {

        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}