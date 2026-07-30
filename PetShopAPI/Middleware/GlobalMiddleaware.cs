
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

class GlobalMiddleaware : IExceptionHandler
{
  private readonly ILogger<GlobalMiddleaware> _logger;

  public GlobalMiddleaware(ILogger<GlobalMiddleaware> logger)
  {
    _logger = logger;

  }

  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    _logger.LogError(exception, "occued the error with code 500; {Message}", exception.Message);

    var detailsProblem = new ProblemDetails
    {
      Status = StatusCodes.Status500InternalServerError,
      Title = "Intern error",
      Detail = "Ocuers error in server try again later",
      Instance = httpContext.Request.Path
    };

    httpContext.Response.StatusCode = detailsProblem.Status.Value;
    await httpContext.Response.WriteAsJsonAsync(detailsProblem, cancellationToken);
    return true;
  }
}