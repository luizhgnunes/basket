using System.Net;

namespace Basket.Common.CustomExceptions
{
    public class CustomHttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public CustomHttpException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public CustomHttpException(string message, Exception innerException, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
