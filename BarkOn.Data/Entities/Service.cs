using BarkOn.Data.Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarkOn.Data.Entities
{
    [Table("Services", Schema = "BarkOn")]
    public class Service : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
