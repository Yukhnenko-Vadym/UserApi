using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestTask.Exceptions;

public class ApiExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException vex)
        {
            context.Result = new BadRequestObjectResult(new
            {
                errors = vex.Errors.Select(e => e.ErrorMessage)
            });
            context.ExceptionHandled = true;
        }
        else
        {
            context.Result = new ObjectResult(new
            {
                error = "An unexpected error occurred",
                details = context.Exception.Message
            })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}