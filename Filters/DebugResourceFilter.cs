using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetCoreFilters.Filters
{
    public class DebugResourceFilter : Attribute, IResourceFilter//,IOrderedFilter
    {
      //  public int Order => 3;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
           Console.WriteLine($"[ResourceFilter 1] :{context.ActionDescriptor.DisplayName} is executing..");
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
           Console.WriteLine($"[ResourceFilter 1] :{context.ActionDescriptor.DisplayName} is executed..");
        }


    }
}
