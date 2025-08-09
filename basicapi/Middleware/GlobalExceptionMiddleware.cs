public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred while processing the request.");
            await HandleExceptionAsync(context, ex);
        }
        
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception )
    {
        // Log the exception (not implemented here for brevity)
        
        context.Response.ContentType = "application/json";
        if (exception is NotFoundException)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
        else if (exception is UnauthorizedAccessException)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
        else if (exception is ValidationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }

        return context.Response.WriteAsJsonAsync(new
        {
            Message = "An unexpected error occurred.",
            Details = exception.Message // You might want to avoid exposing detailed error messages in production
        });
    }
}