using FluentValidation;
using System.Net;
using System.Text.Json;
using Customer.Application.Common.Exceptions;

namespace Customer.API.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            await HandleValidationExceptionAsync(context, ex);
        }
        catch (NotFoundException ex)
        {
            await HandleNotFoundExceptionAsync(context, ex);
        }
        catch (Exception)
        {
            await HandleExceptionAsync(context);
        }
    }

    private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
        var result = JsonSerializer.Serialize(new { errors });

        return context.Response.WriteAsync(result);
    }

    private static Task HandleNotFoundExceptionAsync(HttpContext context, NotFoundException ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;

        var result = JsonSerializer.Serialize(new { error = ex.Message });
        return context.Response.WriteAsync(result);
    }

    private static Task HandleExceptionAsync(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = JsonSerializer.Serialize(new { error = "An unexpected error occurred." });
        return context.Response.WriteAsync(result);
    }
}