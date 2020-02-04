using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomerAsync();
        Task<CustomerModel> GetCustomerByIdAsync(int Id);
        Task<CustomerModel> AddCustomerAsync(CustomerCreateModel input);
        Task<CustomerModel> UpdateCustomerAsync(CustomerUpdateModel input);
        Task DeleteCustomerAsync(int Id);
    }
}
