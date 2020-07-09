using CPN.NetCore.DTO.Core.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CPN.NetCore.API.Middleware
{
    public class ExceptionMiddlewarecs
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddlewarecs(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await CreateErrorResponse(context, ex);
            }
        }

        private async Task CreateErrorResponse(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            string message = string.Empty;
            object data = null;

            //if (env.IsDevelopment())
            //{
                message = ex.Message;
                data = ex.InnerException != null ? ex.InnerException : ex;
            //}
            //else
            //{
            //    message = "An error occurred while trying to execute a request.";
            //}

            // TODO: LOG

            ResponseDTO<object> errorModel = new ResponseDTO<object>(true, message, data);


            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
        }
    }
}
