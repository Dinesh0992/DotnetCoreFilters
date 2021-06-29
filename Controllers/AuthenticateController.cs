using System;
using DotnetCoreFilters.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreFilters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController:ControllerBase
    {
        private readonly ITokenManager tokenManager;

        public AuthenticateController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }
        
        [HttpGet]
          public IActionResult Authenticate(string user, string pwd)
          {
              if(tokenManager.Authenticate(user,pwd))
              {
                  return Ok(new {Token=tokenManager.NewToken()});
              }
              else
              {
                  ModelState.AddModelError("Unauthorized","You are not authorized!..");
                  return Unauthorized(ModelState);
              }
          }
    }
}
