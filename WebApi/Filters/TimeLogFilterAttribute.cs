using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApi.Filters
{
    public class TimeLogFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action executed...");
            Console.WriteLine("Time Takin is ");
            if (context.HttpContext.Items["Stopwatch"] is Stopwatch sw)
            {
                sw.Stop();
                Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Action started...");
            context.HttpContext.Items["Stopwatch"] = sw;

        }
    }
}
