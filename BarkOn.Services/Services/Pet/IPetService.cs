using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public interface IPetService
    {
        Task<IEnumerable<PetModel>> GetPetAsync();
        Task<PetModel> GetPetByIdAsync(int Id);
        Task<PetModel> AddPetAsync(PetCreateModel input);
        Task UpdatePetAsync(PetUpdateModel input);
        Task DeletePetAsync(int Id);
    }
}
