using BarkOn.Data.Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarkOn.Data.Entities
{
    [Table("BookingPackage", Schema = "BarkOn")]
    public class BookingPackage : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int PackageId { get; set; }
        public Booking Bookings { get; set; }
        public Package Packages { get; set; }
    }
}
