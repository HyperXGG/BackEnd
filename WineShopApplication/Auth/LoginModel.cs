using System.ComponentModel.DataAnnotations;

namespace WineShopApplication.Auth
{
    public class LoginModel
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
