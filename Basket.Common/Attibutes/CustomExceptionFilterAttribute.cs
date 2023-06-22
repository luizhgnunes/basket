using Basket.Common.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Basket.Common.Attibutes
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is CustomHttpException customHttpException)
            {
                context.Result = new ObjectResult(new { context.Exception.Message })
                {
                    StatusCode = (int)customHttpException.StatusCode
                };
                context.ExceptionHandled = true;
            }
            else
            {
                _logger.LogError("ERROR: Unhandled exception occurred while executing request: {ex}", context.Exception);
                context.Result = new ObjectResult(new { message = "The application has encountered an unknown error." })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

            base.OnException(context);
        }
    }
}
