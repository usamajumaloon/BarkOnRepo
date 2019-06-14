using BarkOn.Data.Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarkOn.Data.Entities
{
    [Table("Customers", Schema = "BarkOn")]
    public class Customer : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public User Users { get; set; }
    }
}
