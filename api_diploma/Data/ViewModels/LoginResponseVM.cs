using api_diploma.Data.Models;

namespace api_diploma.Data.ViewModels
{
    public class LoginResponseVM
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
