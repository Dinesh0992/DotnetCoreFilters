using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetCoreFilters.Filters
{
    public class DebugResourceFilter2 : Attribute, IResourceFilter//,IOrderedFilter
    {
       // public int Order => 2;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
             Console.WriteLine($"[ResourceFilter2] {context.ActionDescriptor.DisplayName} is executing");
        }
          public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"[ResourceFilter2] {context.ActionDescriptor.DisplayName} is executed");
        }
    }
}
