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
        httpContext.Response.StatusCode = 500;

        await httpContext.Response.WriteAsJsonAsync(
            new ProblemDetails()
        {
            Title = exception.Message,
        });

        return true;
    }
}