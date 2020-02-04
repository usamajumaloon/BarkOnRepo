using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarkOn.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarkOn.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateNewUser([FromBody]CustomerCreateModel model)
        {
            try
            {
                var result = await customerService.AddCustomerAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(CustomerUpdateModel data)
        {
            try
            {
                var result = await customerService.UpdateCustomerAsync(data);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}