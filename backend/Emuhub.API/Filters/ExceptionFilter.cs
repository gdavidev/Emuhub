using Emuhub.Communication.Data;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MyRecipeBook.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is EmuhubCheckedException)
            HandleProjectException(context);
        else
            HandleUnknownException(context);
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ValidationErrorException)
        {
            var exception = context.Exception as ValidationErrorException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ErrorResponse(exception!.Errors));
        }
    }

    private static void HandleUnknownException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorResponse([new { ServerError = ExceptionMessagesResource.UNKNOWN_ERROR }]));
    }
}
