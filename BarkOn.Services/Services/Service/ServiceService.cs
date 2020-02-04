using BarkOn.Common.Utility;
using BarkOn.Data;
using BarkOn.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public class ServiceService : IServiceService
    {
        private readonly string userid;
        private readonly BarkOnDbContext context;
        public ServiceService(BarkOnDbContext context)
        {
            userid = Helper.GetUserId(new HttpContextAccessor());
            this.context = context;
        }

        public async Task<IEnumerable<ServiceModel>> GetServiceAsync()
        {
            try
            {
                var query = await context.Services.Where(a => a.RecordState == Enums.RecordStatus.Active).ToListAsync();
                var model = query.MapObjectList<Service, ServiceModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ServiceModel> GetServiceByIdAsync(int Id)
        {
            try
            {
                var query = await context.Services.Where(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active).FirstOrDefaultAsync();
                var model = query.MapObject<Service, ServiceModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ServiceModel> AddServiceAsync(ServiceCreateModel input)
        {
            try
            {
                var entity = input.MapObject<ServiceCreateModel, Service>();
                entity.CreatedOn = DateTime.UtcNow;
                entity.CreatedById = userid;
                await context.Services.AddAsync(entity);
                await context.SaveChangesAsync();
                var model = input.MapObject<ServiceCreateModel, ServiceModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateServiceAsync(ServiceUpdateModel input)
        {
            try
            {
                using (context)
                {
                    var entity = await context.Services.FirstOrDefaultAsync(a => a.Id == input.Id);
                    entity.Name = input.Name;
                    entity.Price = input.Price;
                    entity.EditedOn = DateTime.UtcNow;
                    entity.EditedById = userid;
                    context.Entry(entity).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteServiceAsync(int Id)
        {
            try
            {
                var entity = await context.Services.FirstOrDefaultAsync(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active);
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
