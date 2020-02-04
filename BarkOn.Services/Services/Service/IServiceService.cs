using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceModel>> GetServiceAsync();
        Task<ServiceModel> GetServiceByIdAsync(int Id);
        Task<ServiceModel> AddServiceAsync(ServiceCreateModel input);
        Task UpdateServiceAsync(ServiceUpdateModel input);
        Task DeleteServiceAsync(int Id);
    }
}
