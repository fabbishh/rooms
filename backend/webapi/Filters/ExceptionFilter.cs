using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using webapi.DTO;

namespace webapi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(message: context.Exception.Message);

            if(context.Exception is InvalidAuthCodeException)
            {
                var error = new Error
                {
                    StatusCode = HttpStatusCode.BadRequest.ToString(),
                    Message = context.Exception.Message,
                };
                context.Result = new JsonResult(error) { StatusCode = (int)HttpStatusCode.BadRequest };
            }
            else
            {
                var error = new Error
                {
                    StatusCode = HttpStatusCode.InternalServerError.ToString(),
                    Message = context.Exception.Message,
                };

                context.Result = new JsonResult(error) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
            
        }
    }
}
