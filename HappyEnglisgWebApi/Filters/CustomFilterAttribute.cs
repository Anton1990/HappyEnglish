using HappyEnglishWebApi.CustomExeption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Net;
using ILogger = Serilog.ILogger;

namespace HappyEnglisgWebApi
{
    public class ExceptionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {                     
            if (context.Exception is InvalidGamerIdException exception)
            {
                int statusCode = (int)HttpStatusCode.NotFound;
                string descriptionError = exception.Message + " [Source: " + context.Controller + "] ";
                context.Result = new ObjectResult(descriptionError)
                {
                    StatusCode = statusCode,
                };
                Log.Error(descriptionError + statusCode);
                context.ExceptionHandled = true;
            }
         }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}