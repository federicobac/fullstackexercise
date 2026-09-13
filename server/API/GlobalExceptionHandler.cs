using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        if (exception is ValidationException)
        {
            httpContext.Response.StatusCode = 401;
        }

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Title = exception.Message,
        });

        return default;
    }
}