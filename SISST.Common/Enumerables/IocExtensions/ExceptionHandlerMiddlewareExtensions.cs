using Comunes.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Comunes.IocExtensions
{
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
