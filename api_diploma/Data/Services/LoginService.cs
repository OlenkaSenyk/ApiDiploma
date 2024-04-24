using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_diploma.Data.Services
{
    public class LoginService
    {
        AppDbContext _context;
        private string _secretKey;

        public LoginService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _secretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        public bool IsUniqueUser(string email)
        {
            return !_context.Users.Any(u => u.Email == email);
        }

        public LoginResponseVM Login(LoginRequestVM request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.ToLower() == request.Email.ToLower());

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return new LoginResponseVM()
                {
                    Token = "",
                    User = null
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseVM response = new LoginResponseVM()
            {
                Token = tokenHandler.WriteToken(token),
                User = user,
            };

            return response;
        }

        public User Register(RegistrationRequestVM request)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                Password = hashedPassword,
                Phone = request.Phone != null ? request.Phone : null,
                Role = request.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            user.Password = "";

            return user;
        }
    }
}
