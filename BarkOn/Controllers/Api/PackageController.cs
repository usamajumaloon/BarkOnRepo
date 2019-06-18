using BarkOn.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService packageService;

        public PackageController(IPackageService packageService)
        {
            this.packageService = packageService;
        }

        [HttpGet]
        public async Task<IEnumerable<PackageModel>> GetAsync()
        {
            try
            {
                return await packageService.GetPackageAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<ActionResult<PackageModel>> GetAsync(int Id)
        {
            try
            {
                var result = await packageService.GetPackageByIdAsync(Id);
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
        public async Task<IActionResult> PostAsync(PackageCreateModel value)
        {
            try
            {
                await packageService.AddPackageAsync(value);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(PackageUpdateModel data)
        {
            try
            {
                await packageService.UpdatePackageAsync(data);
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
                await packageService.DeletePackageAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}