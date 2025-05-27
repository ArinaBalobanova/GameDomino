using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domino
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool UserExists(string login, string password, out Guid userId)
        {
            userId = Guid.Empty;
            var user = _dbContext.Users.FirstOrDefault(u =>
                      u.Login == login &&
                      u.Password == RepeateMethod.Hashing(password));

            if (user != null)
            {
                userId = user.Id;
                return true;
            }
            return false;
        }

        public Guid RegisterNewUser(string login, string password)
        {
            var newUser = new User
            {
                Login = login,
                Password = RepeateMethod.Hashing(password),
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return newUser.Id;
        }

        public bool LoginIsTaken(string login)
        {
            return _dbContext.Users.Any(u => u.Login == login);
        }

        public bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
        }

        public bool ValidateLogin(string login)
        {
            return Regex.IsMatch(login, @"^[a-zA-Z][a-zA-Z0-9]{1,19}$");
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
