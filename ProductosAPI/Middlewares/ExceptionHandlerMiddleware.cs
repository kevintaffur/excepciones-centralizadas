using ProductosAPI.Exceptions;
using ProductosAPI.Utils;

namespace ProductosAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestDelegate> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<RequestDelegate> logger)
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
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = ex switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                NoEncontradoException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            CustomResponse response = new CustomResponse
            {
                StatusCode = statusCode,
                Message = ex.Message,
                Content = null
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
