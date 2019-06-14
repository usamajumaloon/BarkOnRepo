using BarkOn.Common.Utility;
using BarkOn.Data.Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarkOn.Data.Entities
{
    [Table("Pets", Schema = "BarkOn")]
    public class Pet : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public Enums.Size Size { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public User Users { get; set; }
    }
}
