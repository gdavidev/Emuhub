using Emuhub.Exceptions.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.Net;
using Emuhub.Communication.Data.Error;
using Newtonsoft.Json;

namespace Emuhub.API.Filters;

public class ExceptionFilter(ILogger<ExceptionFilter> logger) : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is EmuhubCheckedException or FluentValidation.ValidationException)
            HandleCheckedException(context);
        else
            HandleUnknownException(context);
    }

    private void HandleCheckedException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case ValidationErrorException validationException:
                HandleValidationException(context, validationException);
                break;
            case FluentValidation.ValidationException fluentValidationException:
                HandleFluentValidationException(context, fluentValidationException);
                break;
            case ResourceNotFoundException notFoundException:
                HandleResourceNotFoundException(context, notFoundException);
                break;
            case DuplicatedResourceException duplicatedException:
                HandleDuplicatedResourceException(context, duplicatedException);
                break;
            default:
                HandleUnknownException(context);
                break;
        }
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        var response = new ErrorResponse()
        {
            Message = "Internal Server Error, Try again later.",
            StatusCode = 500,
            Errors = []
        };
        logger.LogCritical(
            "InternalServerError: {Errors} \n {Trace}",
            context.Exception.Message,
            context.Exception.StackTrace
        );

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(response);
    }
    
    private void HandleDuplicatedResourceException(ExceptionContext context,
        DuplicatedResourceException duplicatedException)
    {
        var response = new ErrorResponse()
        {
            Message = duplicatedException.ErrorMessage,
            StatusCode = 409,
            Errors =
            [
                new ErrorResponseDetail()
                {
                    PropertyName = duplicatedException.ResourceName,
                    Errors = [duplicatedException.ErrorMessage],
                }
            ]
        };
                
        logger.LogError(
            "DuplicatedResourceException: {Errors};",
            JObject.FromObject(response).ToString(Formatting.Indented));

        SetContextResponse(
            context,
            HttpStatusCode.Conflict,
            new BadRequestObjectResult(duplicatedException.ErrorMessage));
    }

    private void HandleResourceNotFoundException(
        ExceptionContext context,
        ResourceNotFoundException notFoundException)
    {
        var response = new ErrorResponse()
        {
            Message = notFoundException.ErrorMessage,
            StatusCode = 404,
            Errors =
            [
                new ErrorResponseDetail()
                {
                    PropertyName = notFoundException.ResourceName,
                    Errors = [notFoundException.ErrorMessage],
                }
            ]
        };
                
        logger.LogError(
            "ResourceNotFoundException: {Errors};",
            JObject.FromObject(response).ToString(Formatting.Indented));

        SetContextResponse(
            context,
            HttpStatusCode.NotFound,
            new BadRequestObjectResult(response));
    }

    private void HandleFluentValidationException(
        ExceptionContext context,
        FluentValidation.ValidationException fluentValidationException)
    {
        var response = new ErrorResponse()
        {
            Message = "Validation Error",
            StatusCode = 400,
            Errors = fluentValidationException.Errors
                .GroupBy(err => err.PropertyName)
                .Select(group => new ErrorResponseDetail()
                {
                    PropertyName = group.Key,
                    Errors = group.Select(err => err.ErrorMessage).ToList(),
                }).ToList()
        };
                
        logger.LogError(
            "FluentValidation.ValidationErrorException: {Message};",
            JObject.FromObject(response).ToString(Formatting.Indented));
                
        SetContextResponse(
            context,
            HttpStatusCode.BadRequest,
            new BadRequestObjectResult(response));
    }

    private void HandleValidationException(
        ExceptionContext context,
        ValidationErrorException validationException)
    {
        var response = new ErrorResponse()
        {
            Message = "Validation Error",
            StatusCode = 400,
            Errors = validationException.Errors
                .Select(err => new ErrorResponseDetail()
                {
                    PropertyName = err.PropertyName,
                    Errors = [err.Message],
                }).ToList()
        };
                
        logger.LogError(
            "ValidationErrorException: {Errors};",
            JObject.FromObject(response).ToString(Formatting.Indented));

        SetContextResponse(
            context,
            HttpStatusCode.BadRequest,
            new BadRequestObjectResult(response));
    }

    private static void SetContextResponse<T>(ExceptionContext context, HttpStatusCode code, T response) where T : IActionResult
    {
        context.HttpContext.Response.StatusCode = (int)code;
        context.Result = response;
    }
}