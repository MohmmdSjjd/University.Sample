using System.Net;
using System.Text.Json;
using Domain.Exceptions;
using FluentValidation;

namespace Presentation.WebApi.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ApiException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (ValidationException ex)
        {
            await HandleExceptionAsync(context, ex);
        }
        catch (Exception e)
        {
            var exception = new ApiException(e.Message, (int)HttpStatusCode.InternalServerError);
            await HandleExceptionAsync(context, exception);
        }

        if (!context.Response.HasStarted && context.Response.StatusCode != (int)HttpStatusCode.OK)
        {
            await HandleStatusCodeAsync(context);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, ApiException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception.StatusCode;

        var response = new
        {
            Success = false,
            Message = exception.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 400;

        var response = new
        {
            Success = false,
            Message = exception.Errors.Select(x=>new
            {
                PropertyName= x.PropertyName,
                ErrorMessage = x.ErrorMessage
            })
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleStatusCodeAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            Success = false,
            Message = context.Response.StatusCode switch
            {
                (int)HttpStatusCode.Unauthorized => "Unauthorized access.",
                (int)HttpStatusCode.Forbidden => "Forbidden access.",
                (int)HttpStatusCode.NotFound => "Resource not found.",
                _ => "An error occurred."
            }
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}