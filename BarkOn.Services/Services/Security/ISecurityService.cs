using BarkOn.Services.Models.Security;
using System.Threading.Tasks;

namespace BarkOn.Services.Services.Security
{
    public interface ISecurityService
    {
        Task<LoginModel> LoginAsync(LoginModel loginViewModel);
        Task<UserModel> CreateNewUserAsync(UserModel userModel);
    }
}
