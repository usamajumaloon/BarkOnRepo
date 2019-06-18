using BarkOn.Services.Models.Security;
using BarkOn.Services.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BarkOn.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISecurityService securityService;

        public AccountController(ISecurityService securityService)
        {
            this.securityService = securityService;
        }

        [Route("Authenticate")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await securityService.LoginAsync(model);
                    if (result.Token != null)
                    {
                        return Created("", result);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Login failed!");
            }
        }

        [Route("NewUser")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateNewUser([FromBody]UserModel userModel)
        {
            try
            {
                var result = await securityService.CreateNewUserAsync(userModel);

                if (result.UserName == null)
                {
                    return Conflict(new { message = "Username is already in use" });
                }
                else
                {
                    return Created(string.Empty, result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}