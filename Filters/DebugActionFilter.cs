using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web;

namespace DotnetCoreFilters.Filters
{
    public class DebugActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
             Console.WriteLine($"[ActionFilter] {context.ActionDescriptor.DisplayName} is executing..");
             base.OnActionExecuting(context);
        }
          public override void OnActionExecuted(ActionExecutedContext context)
        {
             Console.WriteLine($"[ActionFilter] {context.ActionDescriptor.DisplayName} is executed..");
             base.OnActionExecuted(context);

        }
    }
}
