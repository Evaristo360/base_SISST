using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SISST.ActionFilters
{
    public class AjaxExceptionHandler : ExceptionFilterAttribute
    {
        //private readonly ILogger<AjaxExceptionHandler> _logger;

        //public AjaxExceptionHandler(ILogger<AjaxExceptionHandler> logger)
        //{
        //    _logger = logger;
        //}

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var exceptionType = exception.GetType();

            //_logger.LogError(exception.ToString());

            context.ExceptionHandled = true;
            //context.HttpContext.Response.Clear();
            //context.HttpContext.Response.TrySkipIisCustomErrors = true;
            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            context.Result = new JsonResult( new
                {
                    statusText = nameof(exceptionType),
                    statusDescription = exception.Message
                }
            );

            base.OnException(context);
        }
    }
}
