using BarkOn.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;

        public ServiceController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceModel>> GetAsync()
        {
            try
            {
                return await serviceService.GetServiceAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<ActionResult<ServiceModel>> GetAsync(int Id)
        {
            try
            {
                var result = await serviceService.GetServiceByIdAsync(Id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ServiceCreateModel value)
        {
            try
            {
                var result = await serviceService.AddServiceAsync(value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(ServiceUpdateModel data)
        {
            try
            {
                await serviceService.UpdateServiceAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete, Route("{Id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            try
            {
                await serviceService.DeleteServiceAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}