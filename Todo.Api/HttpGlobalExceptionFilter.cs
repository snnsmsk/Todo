using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using ToDo.Api.Model;

namespace ToDo.Api
{
    public class HttpGlobalExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;
        public HttpGlobalExceptionFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ToDo logger");
        }

        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            string message;
            HttpStatusCode status;
            
            if (exceptionType == typeof(TodoNotFoundException))
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(TodoException))
            {
                message = context.Exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else
            {
                message = context.Exception.InnerException != null ? context.Exception.InnerException.Message :
                    context.Exception.Message;
                status = HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;

            _logger.LogError(message + " " + context.Exception.StackTrace);

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            // var err = message;

            var json = JsonSerializer.Serialize(message);

            response.WriteAsync(json);
        }
    }
}
