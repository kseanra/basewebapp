using MediatR;
using Microsoft.Extensions.Logging;
public class unhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : notnull
{
    private readonly ILogger<unhandledExceptionBehavior<TRequest, TResponse>> _logger;

    public unhandledExceptionBehavior(ILogger<unhandledExceptionBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the request.");
            throw; // Re-throw the exception to be handled by the global exception middleware
        }
    }
}