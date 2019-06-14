using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public class PhoneService : IPhoneService
    {
        public PhoneService()
        {

        }

        public async Task<IEnumerable<PhoneModel>> GetPhoneAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<PhoneModel> GetPhoneByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<PhoneCreateModel> AddPhoneAsync(PhoneCreateModel input)
        {
            throw new NotImplementedException();
        }
        public async Task UpdatePhoneAsync(PhoneUpdateModel input)
        {
            throw new NotImplementedException();
        }
        public async Task DeletePhoneAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
