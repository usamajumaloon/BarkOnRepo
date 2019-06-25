using BarkOn.Common.Utility;
using System.ComponentModel.DataAnnotations;

namespace BarkOn.Services
{
    public class PetCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public Enums.Size Size { get; set; }
        public string Type { get; set; }
    }
}
