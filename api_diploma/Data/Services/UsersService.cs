using api_diploma.Data.Models;
using api_diploma.Data.ViewModels;

namespace api_diploma.Data.Services
{
    public class UsersService
    {
        AppDbContext _context;
        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserVM user)
        {
            var _user = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Email = user.Email,
                Password = user.Password,
                Phone = user.Phone,
                Role = user.Role,
            };
            
            _context.Users.Add(_user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.FirstOrDefault(p => p.Id == id);

        public User UpdateUserById(int id, UserVM user)
        {
            var _user = _context.Users.FirstOrDefault(p => p.Id == id);

            if (_user != null)
            {
                _user.FirstName = _user.FirstName;
                _user.LastName = _user.LastName;
                _user.MiddleName = _user.MiddleName;
                _user.Email = _user.Email;
                _user.Password = _user.Password;
                _user.Phone = _user.Phone;
                _user.Role = _user.Role;

                _context.SaveChanges();
            }

            return _user;
        }

        public void DeleteUserById(int id)
        {
            var _user = _context.Users.FirstOrDefault(p => p.Id == id);
            if (_user != null)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();
            }
        }
    }
}
