﻿using FoodPlanner.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

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
                { typeof(ArgumentException), HandleBadArgumentException },
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

           HandleUnknownException(context);
        }

        private void HandleEntityAlreadyExistsException(ExceptionContext context)
        {
            var exception = context.Exception as EntityAlreadyExistsException;
            var details = new DetailedInformationObject("Entity already exists", exception.Message);

            context.Result = new ObjectResult(details);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        private void HandleEntityNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as EntityNotFoundException;
            var details = new DetailedInformationObject("Entity not found", exception.Message);

            context.Result = new NotFoundObjectResult(details);
            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.ExceptionHandled = true;
        }

        private void HandleBadArgumentException(ExceptionContext context)
        {
            var exception = context.Exception as ArgumentException;
            var details = new DetailedInformationObject("Invalid argument", exception.Message);

            context.Result = new ObjectResult(details);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new DetailedInformationObject("Something bad happened", "Server encountered a problem while executing the request.");

            context.Result = new ObjectResult(details);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.ExceptionHandled = true;
        }
    }
}