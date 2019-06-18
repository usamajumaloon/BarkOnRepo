using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageModel>> GetPackageAsync();
        Task<PackageModel> GetPackageByIdAsync(int Id);
        Task AddPackageAsync(PackageCreateModel input);
        Task UpdatePackageAsync(PackageUpdateModel input);
        Task DeletePackageAsync(int Id);
    }
}
