using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingModel>> GetBookingAsync();
        Task<BookingModel> GetBookingByIdAsync(int Id);
        Task<BookingModel> AddBookingAsync(BookingCreateModel input);
        Task UpdateBookingAsync(BookingUpdateModel input);
        Task DeleteBookingAsync(int Id);
    }
}