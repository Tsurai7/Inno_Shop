using System.Net;
using System.Text.Json;

namespace Inno_Shop.Services.Products.Presentation.Middleware
{
    public class CustomExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            { 
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.BadRequest;

            var result = string.Empty;

            switch(ex)
            {
                case FluentValidation.ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == null)
            {
                result = JsonSerializer.Serialize(new { errpr = ex.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
