using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace ValladoCalc.PresentationLayer.API.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> logger;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            logger.LogError($"Unhandled error occured: {ex.ToString()}");
            await HandleExceptionAsync(context, code, ex.ToString());
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode code, string message)
    {
        var result = JsonSerializer.Serialize(message);
        var httpResponse = context.Response;
        httpResponse.ContentType = "application/json";
        httpResponse.StatusCode = (int)code;
        await httpResponse.WriteAsync(result);
    }
}