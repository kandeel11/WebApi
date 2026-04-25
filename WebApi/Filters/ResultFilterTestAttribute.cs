using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class ResultFilterTestAttribute :Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
           

        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var originalValue = objectResult.Value;
                var response = new
                {
                    Success = true,
                    Message = "Request processed successfully.",
                    Data = objectResult.Value
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = objectResult.StatusCode ?? 200
                };
            }
        }
    }
}
