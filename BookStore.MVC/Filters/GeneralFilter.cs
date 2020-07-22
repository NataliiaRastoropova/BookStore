using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace BookStore.MVC.Filters
{
    public sealed class GeneralFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
        }
    }
}
