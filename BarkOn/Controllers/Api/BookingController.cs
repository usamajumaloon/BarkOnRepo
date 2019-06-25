using BarkOn.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarkOn.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IEnumerable<BookingModel>> GetAsync()
        {
            try
            {
                return await bookingService.GetBookingAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet, Route("{Id:int}")]
        public async Task<ActionResult<BookingModel>> GetAsync(int Id)
        {
            try
            {
                var result = await bookingService.GetBookingByIdAsync(Id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(BookingCreateModel value)
        {
            try
            {
                await bookingService.AddBookingAsync(value);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(BookingUpdateModel data)
        {
            try
            {
                await bookingService.UpdateBookingAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete, Route("{Id:int}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            try
            {
                await bookingService.DeleteBookingAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}