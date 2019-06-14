using BarkOn.Data.Application;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarkOn.Data.Entities
{
    [Table("Bookings", Schema = "BarkOn")]
    public class Booking : AuditableEntity
    {
        public int Id { get; set; }
        public string Notes { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string UserId { get; set; }
        public int PetId { get; set; }
        public User Users { get; set; }
        public Pet Pets { get; set; }
    }
}
