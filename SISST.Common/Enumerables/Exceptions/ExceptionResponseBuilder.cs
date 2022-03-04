using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace Comunes.Exceptions
{
    public static class ExceptionResponseBuilder
    {

        public static void Build(HttpContext context, Exception exception, out string exceptionName, out int statusCode, out string message)
        {
            var _controller = context.Request.Method;
            var _sourceName = context.Request.Path;

            if (exception is ForbiddenException)
            {
                exceptionName = nameof(ForbiddenException);
                statusCode = (int)HttpStatusCode.Forbidden;
                message = $"Forbidden. {exception.Message}";
            }
            else if (exception is AppException)
            {
                exceptionName = nameof(AppException);
                statusCode = (int)HttpStatusCode.BadRequest;
                message = $"{exception.Message}";
            }

            //unhandled exception type Exception
            else
            {
                exceptionName = "Unhandled exception";
                message = $"Unhandled exception at {_controller} (Path: {_sourceName}) an Item using Service. Check the API log.";
                statusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
