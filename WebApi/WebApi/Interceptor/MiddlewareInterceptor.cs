using WebApi_Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebApi_Interface.Interceptor
{
    public class MiddlewareInterceptor : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (DomainException ex)
            {
                await ReturnErrorResponse(context, ex.Message, HttpStatusCode.Conflict);
            }
            catch (NotFoundException ex)
            {
                await ReturnErrorResponse(context, ex.Message, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                await ReturnErrorResponse(context, "Houve um erro inesperado no servidor", HttpStatusCode.BadRequest);
            }
        }

        private async Task ReturnErrorResponse(HttpContext context, string message, HttpStatusCode code)
        {
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(message);
        }
    }
}
