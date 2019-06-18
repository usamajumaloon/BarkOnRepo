using System;
using System.ComponentModel.DataAnnotations;

namespace BarkOn.Services.Models.Security
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiration { get; set; }
    }
}
