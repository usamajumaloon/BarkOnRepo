using BarkOn.Data.Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarkOn.Data.Entities
{
    [Table("PackageService", Schema = "BarkOn")]
    public class PackageService : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int PackageId { get; set; }
        public Service Services { get; set; }
        public Package Packages { get; set; }
    }
}
