using Emuhub.Application.Serialization;
using Emuhub.Exceptions;
using Emuhub.Exceptions.Exceptions;
using Emuhub.Exceptions.Exceptions.ValidationError;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace Emuhub.API.Filters
{
    public class ExceptionFilter(ILogger<ExceptionFilter> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is EmuhubCheckedException)
                HandleProjectException(context);
            else
                HandleUnknownException(context);
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var exception = context.Exception;

            switch (exception)
            {
                case ValidationErrorException validationException:
                    {
                        var response = ValidationErrorSerializer.ToResponse(validationException.Errors);
                        logger.LogError("ValidationErrorException: {Errors};", response.ToString());

                        SetContextResponse(context, HttpStatusCode.BadRequest, new BadRequestObjectResult(response));
                        break;
                    }
                case FluentValidation.ValidationException fluentValidationException:
                    {
                        var response = JsonSerializer.Serialize(fluentValidationException.Errors);
                        logger.LogError("ValidationErrorException: {Message};", fluentValidationException.Message);

                        SetContextResponse(context, HttpStatusCode.BadRequest, new BadRequestObjectResult(response));
                        break;
                    }
                case ResourceNotFoundException notFoundException:
                    {
                        logger.LogError("ResourceNotFoundException: {Errors};", notFoundException.ErrorMessage);

                        SetContextResponse(context, HttpStatusCode.NotFound, new BadRequestObjectResult(notFoundException.ErrorMessage));
                        break;
                    }
                case DuplicatedResourceException duplicatedException:
                    {
                        logger.LogError("ResourceNotFoundException: {Errors};", duplicatedException.ErrorMessage);

                        SetContextResponse(context, HttpStatusCode.Conflict, new BadRequestObjectResult(duplicatedException.ErrorMessage));
                        break;
                    }
                default:
                    {
                        HandleUnknownException(context);
                        break;
                    }
            }
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var response = new JObject()
            {
                new JProperty("ServerError", ExceptionMessagesResource.UNKNOWN_ERROR)
            };
            logger.LogCritical(
                "InternalServerError: {Errors} \n {Trace}",
                context.Exception.Message,
                context.Exception.StackTrace
            );

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(response);
        }

        private static void SetContextResponse<T>(ExceptionContext context, HttpStatusCode code, T response) where T : IActionResult
        {
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = response;
        }
    }
}
