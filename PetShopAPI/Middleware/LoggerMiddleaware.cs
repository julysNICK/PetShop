using System.Net;
using Microsoft.AspNetCore.Mvc;

class LoggerMiddleaware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<LoggerMiddleaware> _logger;



  public LoggerMiddleaware(RequestDelegate next, ILogger<LoggerMiddleaware> logger)
  {
    _next = next;
    _logger = logger;
  }


  public async Task InvokeAsync(HttpContext http)
  {
    try
    {
      await _next(http);

    }
    catch (System.Exception ex)
    {
      _logger.LogError(ex, "An error occurred while processing the request.");
      http.Response.StatusCode = 500;

      await HandleExceptionAsync(http, ex);

    }

  }


  private Task HandleExceptionAsync(HttpContext context, Exception excepption)
  {
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

    var problem = new ProblemDetails
    {
      Status = context.Response.StatusCode,
      Title = "An error occurred while processing your request.",
      Detail = excepption.Message
    };

    var json = System.Text.Json.JsonSerializer.Serialize(problem);
    return context.Response.WriteAsync(json);
  }

}