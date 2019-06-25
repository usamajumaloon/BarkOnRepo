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
    public class PetService : IPetService
    {
        private readonly BarkOnDbContext context;
        private readonly string userid;

        public PetService(BarkOnDbContext context)
        {
            userid = Helper.GetUserId(new HttpContextAccessor());
            this.context = context;
        }

        public async Task<IEnumerable<PetModel>> GetPetAsync()
        {
            try
            {
                var query = await context.Pets.Where(a => a.UserId == userid && a.RecordState == Enums.RecordStatus.Active).ToListAsync();
                var model = query.MapObjectList<Pet, PetModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PetModel> GetPetByIdAsync(int Id)
        {
            try
            {
                var query = await context.Pets.Where(a => a.UserId == userid && a.Id == Id && a.RecordState == Enums.RecordStatus.Active).FirstOrDefaultAsync();
                var model = query.MapObject<Pet, PetModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<PetModel> AddPetAsync(PetCreateModel input)
        {
            try
            {
                var entity = input.MapObject<PetCreateModel, Pet>();
                entity.CreatedOn = DateTime.UtcNow;
                await context.Pets.AddAsync(entity);
                await context.SaveChangesAsync();
                var model = input.MapObject<PetCreateModel, PetModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdatePetAsync(PetUpdateModel input)
        {
            try
            {
                using (context)
                {
                    var entity = await context.Pets.FirstOrDefaultAsync(a => a.Id == input.Id);
                    entity.Name = input.Name;
                    entity.Age = input.Age;
                    entity.Size = input.Size;
                    entity.Type = input.Type;
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
        public async Task DeletePetAsync(int Id)
        {
            try
            {
                var entity = await context.Pets.FirstOrDefaultAsync(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active);
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
