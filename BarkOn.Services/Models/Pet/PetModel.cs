using BarkOn.Common.Utility;

namespace BarkOn.Services
{
    public class PetModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Enums.Size Size { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
    }
}
