using Microsoft.AspNetCore.Diagnostics;
using pos.application.DTOs.Exceptions;
using pos.domain.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IHostEnvironment _env;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var traceId = httpContext.TraceIdentifier;

        var response = new ApiErrorResponse
        {
            TraceId = traceId,
            Instance = httpContext.Request.Path
        };

        switch (exception)
        {
            case ValidationAppException vex:
                response.Status = vex.StatusCode;
                response.Title = vex.Title;
                response.Detail = vex.Message;
                response.Errors = (Dictionary<string, string[]>)vex.Errors;
                _logger.LogWarning("Validation error: {Message}", vex.Message);
                break;

            case AppException appEx:
                response.Status = appEx.StatusCode;
                response.Title = appEx.Title;
                response.Detail = appEx.Message;
                _logger.LogWarning("{ExceptionType}: {Message}", appEx.GetType().Name, appEx.Message);
                break;

            default:
                response.Status = StatusCodes.Status500InternalServerError;
                response.Title = "An unexpected error occurred";
                response.Detail = _env.IsDevelopment()
                    ? exception.ToString()
                    : "An internal error occurred. Please contact support with the trace ID.";
                _logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);
                break;
        }

        httpContext.Response.StatusCode = response.Status;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}