using BarkOn.Common.Utility;
using System;
using System.ComponentModel.DataAnnotations;
namespace BarkOn.Data.Application
{
    public abstract class AuditableEntity
    {
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public int CreatedById { get; set; }
        public DateTime? EditedOn { get; set; }
        public int? EditedById { get; set; }
        public Enums.RecordStatus RecordState { get; set; }
        protected AuditableEntity()
        {
            CreatedOn = DateTime.UtcNow;
            EditedOn = DateTime.UtcNow;
            RecordState = Enums.RecordStatus.Active;
        }
    }
}
