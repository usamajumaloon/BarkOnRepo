﻿using BarkOn.Common.Utility;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarkOn.Data.Entities
{
    [Table("Users", Schema = "BarkOn")]
    public class User: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public bool IsAdmin { get; set; }


        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public string CreatedById { get; set; }
        public DateTime? EditedOn { get; set; } = DateTime.UtcNow;
        public string EditedById { get; set; }
        public Enums.RecordStatus RecordState { get; set; }
    }
}
