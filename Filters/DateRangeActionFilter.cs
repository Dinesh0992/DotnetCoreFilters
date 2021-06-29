using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotnetCoreFilters.Filters
{
    public class DateRangeActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            DateTime begindate = (DateTime)context.ActionArguments["begindate"];
            DateTime enddate = (DateTime)context.ActionArguments["enddate"];
            if (begindate > enddate)
            { 
                context.ModelState.AddModelError("Begin Date","Begin Date should not be greateer than End Date.. ");
                context.Result=new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
