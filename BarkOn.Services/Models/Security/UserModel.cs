using System.ComponentModel.DataAnnotations;

namespace BarkOn.Services.Models.Security
{
    public class UserModel
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
