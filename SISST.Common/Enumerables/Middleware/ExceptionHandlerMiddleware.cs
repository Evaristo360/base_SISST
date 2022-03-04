using Comunes.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;


namespace Comunes.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
            }
        }

        private Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {
            var _controller = context.Request.Method;
            var _sourceName = context.Request.Path;

            ExceptionResponseBuilder.Build(context, exception, out string exceptionName, out int statusCode, out string message);

            //log and return
            _logger.LogError($"{_controller}.{_sourceName}: {exceptionName}. Additional information: {exception}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var result = JsonConvert.SerializeObject(new
            {
                StatusCode = statusCode,
                ErrorMessage = message
            });

            return context.Response.WriteAsync(result);
        }

    }

}
