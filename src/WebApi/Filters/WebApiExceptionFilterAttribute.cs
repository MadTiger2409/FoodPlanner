using FoodPlanner.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlanner.WebApi.Filters
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public WebApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(EntityAlreadyExistsException), HandleEntityAlreadyExistsException },
                { typeof(EntityNotFoundException), HandleEntityNotFoundException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleEntityAlreadyExistsException(ExceptionContext context)
        {
            var exception = context.Exception as EntityAlreadyExistsException;

            var details = new ProblemDetails
            {
                Title = "Entity already exists",
                Detail = exception.Message,
            };

            context.Result = new ObjectResult(details);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        private void HandleEntityNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as EntityNotFoundException;

            var details = new ProblemDetails
            {
                Title = "Entity not found",
                Detail = exception.Message,
            };

            context.Result = new ObjectResult(details);
            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.ExceptionHandled = true;
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
        }

        private void HandleUnknownException(ExceptionContext context)
        {
        }
    }
}