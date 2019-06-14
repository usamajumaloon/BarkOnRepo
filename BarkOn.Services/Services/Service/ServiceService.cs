using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public class ServiceService : IServiceService
    {
        public ServiceService()
        {

        }

        public async Task<IEnumerable<ServiceModel>> GetServiceAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceModel> GetServiceByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceCreateModel> AddServiceAsync(ServiceCreateModel input)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateServiceAsync(ServiceUpdateModel input)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteServiceAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
