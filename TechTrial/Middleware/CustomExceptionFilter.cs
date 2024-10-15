using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace S.Core.Utils.ExceptionMiddleware
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.ContentType = "application/json";

            // Indica que la excepción ha sido manejada
            context.ExceptionHandled = true;
            statusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.StatusCode = statusCode;

            // Establece el resultado que se enviará al cliente
            context.Result = new ObjectResult(new
            {
                isSuccess = false,
                statusCode = statusCode,
                error = context.Exception.Message,
            });
        }
    }
}
