using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarkOn.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarkOn.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
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
            return await packageService.GetPackageAsync();
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<PackageModel> GetAsync(int Id)
        {
            return await packageService.GetPackageByIdAsync(Id);
        }

        [HttpPost]
        public async Task<PackageCreateModel> PostAsync(PackageCreateModel value)
        {
            return await packageService.AddPackageAsync(value);
        }

        [HttpPut]
        public async Task PutAsync(PackageUpdateModel data)
        {
            await packageService.UpdatePackageAsync(data);
        }

        [HttpDelete, Route("{Id:int}")]
        public async Task DeleteAsync(int Id)
        {
            await packageService.DeletePackageAsync(Id);
        }
    }
}