using System;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetCoreFilters.TokenAuthentication;

namespace DotnetCoreFilters.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));
            bool result = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                result = false;
            }
            string token = string.Empty;
            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;
                // if (!tokenManager.VerifyToken(token))
                // {
                //     result = false;
                // }
                try { var claimPrincipal = tokenManager.VerifyToken(token); }
                catch (Exception ex) 
                {
                     result = false; 
                     context.ModelState.AddModelError("Unauthorized",ex.ToString());
                }



            }
            else
            {
                context.ModelState.AddModelError("Unauthorized", "You are not authorized");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
