using System.Diagnostics;
using Application.Common.Exceptions;
using Application.Exceptions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Api.Middlewares;
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment environment) : IExceptionHandler
{
    private const bool IsLastStopInPipeline = true;

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
        Exception exception, CancellationToken cancellationToken)
    {
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        logger.LogError(exception, "Could not process a request on machine {MachineName} with trace id {TraceId}",
            Environment.MachineName, traceId);

        (int statusCode, string title) = MapException(exception);

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Extensions = { ["traceId"] = traceId },
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        };
        if (!environment.IsProduction())
        {
            problemDetails.Detail = exception.Message;
        }

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);
        return IsLastStopInPipeline;
    }

    private static (int statusCode, string title) MapException(Exception exception)
    {
        return exception switch
        {
            ForbiddenAccessException => (403, "Forbidden access"),
            ValidationException => (400, "A validation error occurred"),
            NotFoundException => (404, "Resource not found"),
            UnsupportedRoleException => (403, "Unsupported role"),
            _ => (500, "An unhandled error occurred")
        };
    }
}