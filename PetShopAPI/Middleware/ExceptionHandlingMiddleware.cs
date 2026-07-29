using System.Diagnostics;

class ExceptionHandlingMiddleware
{
  public readonly RequestDelegate _next;

  public ExceptionHandlingMiddleware(RequestDelegate next)
  {
    _next = next;

  }

  public async Task InvokeAsync(HttpContext context)
  {
    var timer = Stopwatch.StartNew();

    await _next(context);

    timer.Stop();

    var totalTimeRequest = timer.ElapsedMilliseconds;


    Console.WriteLine($"[perfomance] Router: {context.Request.Path}> time: {totalTimeRequest}ms");

  }
}