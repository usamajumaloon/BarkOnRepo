using BarkOn.Common.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
namespace BarkOn.Data.Application
{
    public abstract class AuditableEntity
    {
        [Required]
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public DateTime? EditedOn { get; set; }
        public string EditedById { get; set; }
        public Enums.RecordStatus RecordState { get; set; }
        protected AuditableEntity()
        {
            CreatedOn = DateTime.UtcNow;
            CreatedById = Helper.GetUserId(new HttpContextAccessor());
            EditedOn = DateTime.UtcNow;
            RecordState = Enums.RecordStatus.Active;
        }
    }
}
