using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreBackEnd.Dto;
using StoreBackEnd.Services;

namespace StoreBackEnd.Controllers
{
    [EnableCors("StorePolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


      private ILoginService loginService;
        private ILogger<LoginController> logger;

        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            this.loginService = loginService;
            this.logger = logger;
        }

        // POST: api/Users
        [HttpPost]
        [Route("register")]
        public bool Post([FromBody]SignupDetails add)
        {
            if (add != null)
            {
                var r = loginService.PostSignupDetails(add);
                if (r == "Posted")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        ////////

        [HttpPost]
    
        public async Task<IActionResult> POSTuser([FromBody] LoginDto value)
        {
            try
            {
                if (value != null)
                {
                    var token = loginService.UserCheck(value);
                    if (token == null)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        return Ok(token);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(500);
                throw;
            }
        }









        //////////////

    }

}
