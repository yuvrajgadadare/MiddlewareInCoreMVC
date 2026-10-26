namespace MiddlewareInCoreMVC.Middlewares
{
    public class LoggingMiddleware
    {
        RequestDelegate _next;
        ILogger<LoggingMiddleware> _logger;
        public LoggingMiddleware(RequestDelegate next,ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LoggingMiddleware>();

        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Requested Url=>{Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");

            await _next(context);
        }

    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogUrl(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
