using System.Net;
using Newtonsoft.Json;
using Ostral.Core.ViewModel;

namespace Ostral.WEB.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly bool _isProdEnv;

        public ExceptionMiddleware(RequestDelegate next,
                ILogger<ExceptionMiddleware> logger, IHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _next = next;
            _isProdEnv = hostingEnvironment.IsProduction();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "text/html";
                var errorResponse = ResponseVM<object>.Fail(new []{error.Message});

                if (!_isProdEnv)
                    throw;
                
                switch (error)
                {
                    case UnauthorizedAccessException e:
                        _logger.LogError(
                            e,
                            e.StackTrace,
                            e.StackTrace,
                            e.Source);
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        errorResponse.Message = e.Message;
                        break;
                    case ArgumentOutOfRangeException e:
                        _logger.LogError(
                            e,
                            e.StackTrace, 
                            e.Source, 
                            e.ToString());
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorResponse.Message = e.Message;
                        break;
                    case ArgumentNullException e:
                        _logger.LogError(
                            e, 
                            e.StackTrace, 
                            e.Source, 
                            e.ToString());
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorResponse.Message = e.Message;
                        break;
                    default:
                        _logger.LogError(
                            error,
                            error.Source,
                            error.InnerException,
                            error.Message,
                            error.ToString());
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        errorResponse.StatusCode = (int) HttpStatusCode.InternalServerError;
                        errorResponse.Message = "Internal Server Error.";
                        break;
                }

                var result = JsonConvert.SerializeObject(errorResponse);
                await response.WriteAsync(result);
            }
        }
    }
}