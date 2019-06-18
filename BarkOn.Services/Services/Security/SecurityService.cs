using BarkOn.Common.Utility;
using BarkOn.Data.Entities;
using BarkOn.Services.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BarkOn.Services.Services.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public SecurityService(SignInManager<User> signInManager,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<LoginModel> LoginAsync(LoginModel model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        //Create the token
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            configuration["Tokens:Issuer"],
                            configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(1),
                            signingCredentials: creds
                            );

                        var results = new LoginModel
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            TokenExpiration = token.ValidTo
                        };

                        return results;
                    }
                }

                return new LoginModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModel> CreateNewUserAsync(UserModel userModel)
        {
            try
            {
                var storeUser = userModel.MapObject<UserModel, User>();
                var user = await userManager.CreateAsync(storeUser, userModel.Password);
                if (user.Succeeded)
                {
                    return userModel;
                }
                else
                {
                    return new UserModel();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
