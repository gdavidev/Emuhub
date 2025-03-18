using Emuhub.Application.Serialization;
using Emuhub.Communication.Data;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
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
        var exception = context.Exception;

        if (exception is ValidationErrorException validationException)
        {
            var response = ValidationErrorSerializer.ToResponse(validationException.Errors);

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(response);
            return;
        }
        if (exception is ResourceNotFoundException notFoundException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new NotFoundObjectResult(notFoundException.ErrorMessage);
            return;
        }
        if (exception is DuplicatedResourceException duplicatedException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            context.Result = new ConflictObjectResult(duplicatedException.ErrorMessage);
            return;
        }

        HandleUnknownException(context);
    }

    private static void HandleUnknownException(ExceptionContext context)
    {
        var response = new JObject()
        {
            new JProperty("ServerError", ExceptionMessagesResource.UNKNOWN_ERROR)
        };

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(response);
    }
}
