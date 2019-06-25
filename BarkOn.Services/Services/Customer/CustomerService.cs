using BarkOn.Common.Utility;
using BarkOn.Data;
using BarkOn.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BarkOnDbContext context;
        private readonly UserManager<User> userManager;

        public CustomerService(BarkOnDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerAsync()
        {
            try
            {
                var query = await context.Customers.Where(a => a.RecordState == Enums.RecordStatus.Active).ToListAsync();
                var model = query.MapObjectList<Customer, CustomerModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<CustomerModel> GetCustomerByIdAsync(int Id)
        {
            try
            {
                var query = await context.Customers.Where(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active).FirstOrDefaultAsync();
                var model = query.MapObject<Customer, CustomerModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<CustomerModel> AddCustomerAsync(CustomerCreateModel input)
        {
            try
            {
                var entity = input.MapObject<CustomerCreateModel, Customer>();

                var createUser = new User()
                {
                    UserName = input.UserName,
                    PhoneNumber = input.PhoneNo,
                    Name = input.Name,
                    Email = input.Email,
                    IsAdmin = input.IsAdmin
                };

                var user = await userManager.CreateAsync(createUser, input.Password);

                entity.UserId = createUser.Id;
                entity.CreatedById = createUser.Id;
                entity.CreatedOn = DateTime.UtcNow;

                await context.Customers.AddAsync(entity);
                await context.SaveChangesAsync();

                var model = createUser.MapObject<User, CustomerModel>();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateCustomerAsync(CustomerUpdateModel input)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteCustomerAsync(int Id)
        {
            try
            {
                var entity = await context.Customers.FirstOrDefaultAsync(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active);
                entity.RecordState = Enums.RecordStatus.Inactive;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
