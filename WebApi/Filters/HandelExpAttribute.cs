using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class HandelExpAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new
            {
                Success = false,
                Message = "An unexpected error occurred.",
                Details = context.Exception.Message
            };
            context.Result = new JsonResult(response)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
