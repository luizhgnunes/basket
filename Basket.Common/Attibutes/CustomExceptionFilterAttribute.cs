using Basket.Common.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Basket.Common.Attibutes
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
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
                base.OnException(context);
            }
        }
    }
}
