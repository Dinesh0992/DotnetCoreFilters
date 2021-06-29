using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetCoreFilters.Filters
{
    public class DebugResourceFilter3:Attribute,IResourceFilter//,IOrderedFilter
    {
    //    public int Order => 1;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
             Console.WriteLine($"[ResourceFilter3] {context.ActionDescriptor.DisplayName} is executing");
        }
          public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"[ResourceFilter3] {context.ActionDescriptor.DisplayName} is executed");
        }
    }
}
