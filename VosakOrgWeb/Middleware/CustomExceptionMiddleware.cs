using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VosakOrgWeb.Exceptions;
using VosakOrgWeb.Response;

namespace VosakOrgWeb.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (VosakOrgWebException ex)
            {
                // Log for custom exception
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception exceptionObj)
            {
                // Log for unintentional exception
                await HandleExceptionAsync(context, exceptionObj);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result = null;
            context.Response.ContentType = "application/json";
            if (exception.GetType() == typeof(VosakOrgWebException))
            {
                var statusCode = (int)((VosakOrgWebException)exception).StatusCode;
                result = ApiResponse.ErrorResponse(exception.Message, statusCode).ToString();
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = ((VosakOrgWebException) exception).ContentType;
            } 
            else
            {
                result = ApiResponse.ErrorResponse("Runtime Error").ToString();
                context.Response.StatusCode = 400;
            }
            return context.Response.WriteAsync(result);
        }
        
        // private Task HandleExceptionAsync(HttpContext context, Exception exception)
        // {
        //     string result = new ErrorDetails() { Message = exception.Message, StatusCode = (int)HttpStatusCode.InternalServerError }.ToString();
        //     context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //     return context.Response.WriteAsync(result);
        // }
    }

}