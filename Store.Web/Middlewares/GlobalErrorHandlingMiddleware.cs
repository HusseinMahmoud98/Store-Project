using Azure;
using Store.Domain.Exceptions.BadRequest;
using Store.Domain.Exceptions.NotFound;
using Store.Shared.ErrorModels;
using System.Threading.Tasks;

namespace Store.Web.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    context.Response.ContentType = "application/json";
                    var response = new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        ErrorMessage = $"End point {context.Request.Path} was not found"
                    };

                    await context.Response.WriteAsJsonAsync(response);
                }

                
            }
              
            catch (Exception ex)
            {
                //logic
                //1. Set Status Code Of Response
                context.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError,
                };
                    
              
                //2. Set Content Type Of Response
                context.Response.ContentType = "application/json";

                //3. Set Body Of Response
                var response = new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = ex.Message,
                };
                
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}