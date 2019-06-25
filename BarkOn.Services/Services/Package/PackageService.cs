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
    public class PackageService : IPackageService
    {
        private readonly string userid;
        private readonly BarkOnDbContext context;

        public PackageService(BarkOnDbContext context)
        {
            userid = Helper.GetUserId(new HttpContextAccessor());
            this.context = context;
        }

        public async Task<IEnumerable<PackageModel>> GetPackageAsync()
        {
            try
            {
                var query = await context.Packages.Where(a => a.RecordState == Enums.RecordStatus.Active).ToListAsync();
                var model = query.MapObjectList<Package, PackageModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PackageModel> GetPackageByIdAsync(int Id)
        {
            try
            {
                var query = await context.Packages.Where(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active).FirstOrDefaultAsync();
                var model = query.MapObject<Package, PackageModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PackageModel> AddPackageAsync(PackageCreateModel input)
        {
            try
            {
                var entity = input.MapObject<PackageCreateModel, Package>();
                entity.CreatedOn = DateTime.UtcNow;
                entity.CreatedById = userid;
                await context.Packages.AddAsync(entity);
                await context.SaveChangesAsync();
                var model = input.MapObject<PackageCreateModel, PackageModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdatePackageAsync(PackageUpdateModel input)
        {
            try
            {
                using (context)
                {
                    var entity = await context.Packages.FirstOrDefaultAsync(a => a.Id == input.Id);
                    entity.Name = input.Name;
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
        public async Task DeletePackageAsync(int Id)
        {
            try
            {
                var entity = await context.Packages.FirstOrDefaultAsync(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active);
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
