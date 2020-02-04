using BarkOn.Common.Utility;
using BarkOn.Data;
using BarkOn.Data.Entities;
using Microsoft.AspNetCore.Http;
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
        private readonly string userid;
        private readonly BarkOnDbContext context;
        private readonly UserManager<User> userManager;

        public CustomerService(BarkOnDbContext context, UserManager<User> userManager)
        {
            userid = Helper.GetUserId(new HttpContextAccessor());
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
        public async Task<CustomerModel> UpdateCustomerAsync(CustomerUpdateModel input)
        {
            try
            {
                var model = await context.Customers.Where(s => s.Id == input.Id && s.RecordState == Enums.RecordStatus.Active).FirstOrDefaultAsync();
                if (model == null)
                {
                    throw new Exception("Record not found, please enter a valid ID!");
                }
                model.Name = input.Name;
                model.PhoneNo = input.PhoneNo;
                model.EditedById = userid;
                model.EditedOn = DateTime.UtcNow;

                var user = await userManager.FindByIdAsync(model.UserId);
                user.UserName = input.UserName;
                user.Email = input.Email;

                var hashedNewPassword = userManager.PasswordHasher.HashPassword(user, input.Password);
                user.PasswordHash = hashedNewPassword;

                await userManager.UpdateAsync(user);
                await context.SaveChangesAsync();

                return model.MapObject<Customer, CustomerModel>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteCustomerAsync(int Id)
        {
            try
            {
                var entity = await context.Customers.FirstOrDefaultAsync(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active);
                entity.RecordState = Enums.RecordStatus.Inactive;
                entity.EditedOn = DateTime.UtcNow;
                entity.EditedById = userid;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
