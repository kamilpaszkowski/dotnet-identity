using System.Linq;
using System.Net;
using Euvic.StaffTraining.Common;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Euvic.StaffTraining.WebAPI.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is ValidationException validationException))
                return;

            var validationResults = validationException.Errors?
               .GroupBy(x => x.PropertyName)
               .Select(error => new PropertyValidationResult
               {
                   PropertyName = error.Key,
                   Errors = error.Select(e => e.ErrorMessage).ToArray()
               });

            var message = validationResults.Any() ? string.Empty : validationException.Message;

            context.Result = new ObjectResult(new ValidationErrorResponse { ValidationResults = validationResults, Message = message })
            {
                ContentTypes = new MediaTypeCollection { "application/json" },
                StatusCode = (int)HttpStatusCode.BadRequest
            };

            context.ExceptionHandled = true;
        }
    }
}
