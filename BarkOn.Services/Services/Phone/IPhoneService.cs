using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public interface IPhoneService
    {
        Task<IEnumerable<PhoneModel>> GetPhoneAsync();
        Task<PhoneModel> GetPhoneByIdAsync(int Id);
        Task<PhoneCreateModel> AddPhoneAsync(PhoneCreateModel input);
        Task UpdatePhoneAsync(PhoneUpdateModel input);
        Task DeletePhoneAsync(int Id);
    }
}
