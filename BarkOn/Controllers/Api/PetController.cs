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
    public class PetController : ControllerBase
    {
        private readonly IPetService petService;

        public PetController(IPetService petService)
        {
            this.petService = petService;
        }

        [HttpGet]
        public async Task<IEnumerable<PetModel>> GetAsync()
        {
            try
            {
                return await petService.GetPetAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<ActionResult<PetModel>> GetAsync(int Id)
        {
            try
            {
                var result = await petService.GetPetByIdAsync(Id);
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
        public async Task<IActionResult> PostAsync(PetCreateModel value)
        {
            try
            {
                await petService.AddPetAsync(value);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(PetUpdateModel data)
        {
            try
            {
                await petService.UpdatePetAsync(data);
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
                await petService.DeletePetAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}