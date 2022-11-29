using HappyEnglishWebApi.CustomExeption;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Net;


namespace HappyEnglisgWebApi
{
    public class CustomFilterDI : Attribute, IActionFilter
    {
        private readonly ILogger<CustomFilterDI> _logger;
        public CustomFilterDI(ILogger<CustomFilterDI> logger)
        {
            _logger = logger;
        }
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
                _logger.LogWarning(descriptionError + statusCode);
                context.ExceptionHandled = true;
            }
   
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

    }
}