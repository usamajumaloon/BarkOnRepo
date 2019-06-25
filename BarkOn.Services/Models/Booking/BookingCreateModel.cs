using System;

namespace BarkOn.Services
{
    public class BookingCreateModel
    {
        public string Notes { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int PetId { get; set; }
    }
}
