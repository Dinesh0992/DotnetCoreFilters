using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetCoreFilters.Filters
{
    public class VersionDiscontinueResourceFilter : Attribute, IResourceFilter
    {
         public void OnResourceExecuting(ResourceExecutingContext context)
        {
           if(context.HttpContext.Request.Path.Value.ToLower().Contains("v1"))
           {
               context.Result=new BadRequestObjectResult(new 
               {
                   Success=false,
                   Error="This version of API is obselete.Use v2 version"

               });
           }
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

       
    }
}
