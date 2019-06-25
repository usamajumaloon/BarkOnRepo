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
    public class BookingService : IBookingService
    {
        private readonly string userid;
        private readonly BarkOnDbContext context;

        public BookingService(BarkOnDbContext context)
        {
            userid = Helper.GetUserId(new HttpContextAccessor());
            this.context = context;
        }

        public async Task<IEnumerable<BookingModel>> GetBookingAsync()
        {
            try
            {
                var query = await context.Bookings.Where(a => a.RecordState == Enums.RecordStatus.Active).ToListAsync();
                var model = query.MapObjectList<Booking, BookingModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BookingModel> GetBookingByIdAsync(int Id)
        {
            try
            {
                var query = await context.Bookings.Where(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active).FirstOrDefaultAsync();
                var model = query.MapObject<Booking, BookingModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<BookingModel> AddBookingAsync(BookingCreateModel input)
        {
            try
            {
                var entity = input.MapObject<BookingCreateModel, Booking>();
                entity.CreatedOn = DateTime.UtcNow;
                entity.CreatedById = userid;
                entity.UserId = userid;
                await context.Bookings.AddAsync(entity);
                await context.SaveChangesAsync();
                var model = input.MapObject<BookingCreateModel, BookingModel>();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateBookingAsync(BookingUpdateModel input)
        {
            try
            {
                using (context)
                {
                    var entity = await context.Bookings.FirstOrDefaultAsync(a => a.Id == input.Id);
                    entity.Notes = input.Notes;
                    entity.FromDate = input.FromDate;
                    entity.ToDate = input.ToDate;
                    entity.PetId = input.PetId;
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
        public async Task DeleteBookingAsync(int Id)
        {
            try
            {
                var entity = await context.Bookings.FirstOrDefaultAsync(a => a.Id == Id && a.RecordState == Enums.RecordStatus.Active);
                entity.RecordState = Enums.RecordStatus.Inactive;
                entity.EditedById = userid;
                entity.EditedOn = DateTime.UtcNow;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
