﻿namespace BarkOn.Services
{
    public class CustomerCreateModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public bool IsAdmin { get; set; }
    }
}
