using BarkOn.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public class PackageService : IPackageService
    {
        private readonly BarkOnDbContext context;

        public PackageService(BarkOnDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PackageModel>> GetPackageAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<PackageModel> GetPackageByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<PackageCreateModel> AddPackageAsync(PackageCreateModel input)
        {
            throw new NotImplementedException();
        }
        public async Task UpdatePackageAsync(PackageUpdateModel input)
        {
            throw new NotImplementedException();
        }
        public async Task DeletePackageAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
