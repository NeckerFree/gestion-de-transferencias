using FluentValidation;
using GestionTransferencias.Domain.Exceptions.Base;
using System;
using System.Net;
using System.Text.Json;

namespace GestionTransferencias.Api.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "An exception occurred: {Message}", exception.Message);

                var statusCode = GetStatusCode(exception);
                var response = CreateResponse(exception, statusCode);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(response);
               
            }
        }



        private static int GetStatusCode(Exception exception) =>
         exception switch
         {
             ValidationException => (int)HttpStatusCode.BadRequest, // 400
             NotFoundException =>(int)HttpStatusCode.NotFound, //404
             _ => (int)HttpStatusCode.InternalServerError // 500 (default)
         };

        private static string CreateResponse(Exception exception, int statusCode)
        {
            return exception switch
            {
                ValidationException validationException => JsonSerializer.Serialize(new
                {
                    StatusCode = statusCode,
                    Message = "Validation failed",
                    Errors = validationException.Errors.Select(e => new
                    {
                        e.PropertyName,
                        e.ErrorMessage
                    })
                }),

                NotFoundException notFoundException => JsonSerializer.Serialize(new
                {
                    StatusCode = statusCode,
                    Message = "Not Found",
                    
                }),
                _ => JsonSerializer.Serialize(new
                {
                    StatusCode = statusCode,
                    Message = "An error occurred"
                })
            };
        }
    }
}
