using BarkOn.Common.Utility;
using BarkOn.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace BarkOn.Data
{
    public class BarkOnSeeder
    {
        private readonly BarkOnDbContext _ctx;
        private readonly UserManager<User> _userManager;

        public BarkOnSeeder(BarkOnDbContext ctx, UserManager<User> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("admin@gmail.com");

            if (user == null)
            {
                user = new User()
                {
                    Name = "Admin",
                    IsAdmin = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedById = "",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    RecordState = Enums.RecordStatus.Active
                };

                var result = await _userManager.CreateAsync(user, "Admin@123");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create user");
                }
            }

            _ctx.SaveChanges();
        }
    }
}