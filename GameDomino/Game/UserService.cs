
using System.Text.RegularExpressions;


namespace GameDomino.Game
{
    /// <summary>
    /// Сервисный класс для работы с бд 
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        /// <summary>
        /// Конструктор сервисного класса
        /// </summary>
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Проверка существует ли пользователь
        /// </summary>
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
        /// <summary>
        /// Регистрация нового пользователя 
        /// </summary>
        public Guid RegisterNewUser(string login, string password)
        {
            var newUser = new User
            {
                Login = login,
                Password = RepeateMethod.Hashing(password),
                Rating = 0
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return newUser.Id;
        }
        /// <summary>
        /// Проверка логина 
        /// </summary>
        public bool LoginIsTaken(string login)
        {
            return _dbContext.Users.Any(u => u.Login == login);
        }
        /// <summary>
        /// Проверка пароля на требования 
        /// </summary>

        public bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
        }
        /// <summary>
        /// Проверка логина на требования
        /// </summary>
        public bool ValidateLogin(string login)
        {
            return Regex.IsMatch(login, @"^[a-zA-Z][a-zA-Z0-9]{1,19}$");
        }
        /// <summary>
        /// Получает всех пользователей из базы данных вместе с их рейтингами
        /// </summary>
        public IEnumerable<User> GetAllUsersWithRatings()
        {
            return _dbContext.Users.ToList();
        }
        /// <summary>
        /// Освобождает ресурсы контекста базы данных
        /// </summary>
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
