using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;
using TrainMateServer.Application.Errors;

namespace TrainMateServer.Presentation.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private const string UnhandledExceptionMessage = "Something unexpected happened. Please Try again later.";

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<CustomExceptionFilter>>();
            logger.LogError(context.Exception, "Unhandled exception");

            if (context.Exception is BusinessException businessException)
            {
                context.HttpContext.Response.StatusCode = 400;
                context.HttpContext.Response.ContentType = "application/problem+json";
                await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails
                {
                    Status = 400,
                    Title = $"business_exception/{businessException.ErrorCode}",
                    Detail = UnhandledExceptionMessage,
                }));
            }
            else
            {
                context.HttpContext.Response.StatusCode = 500;
                context.HttpContext.Response.ContentType = "application/problem+json";
                await context.HttpContext.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails
                {
                    Status = 500,
                    Title = "unhandled_exception",
                    Detail = UnhandledExceptionMessage,
                }));
            }
        }
    }
}
