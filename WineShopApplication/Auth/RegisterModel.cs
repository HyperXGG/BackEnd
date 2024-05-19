using System.ComponentModel.DataAnnotations;

namespace WineShopApplication.Auth
{
    public class RegisterModel
    {
        public required string UserName { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }

        [Compare(nameof(Password))]
        public required string ConfirmPassword { get; set; }
        public DateTime Birthday { get; set; } 
    }
}
