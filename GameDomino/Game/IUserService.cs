namespace GameDomino.Game
{
    /// <summary>
    /// Интерфейс сервиса для работы с пользователями
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Проверяет существование пользователя с указанными учетными данными
        /// </summary>
        bool UserExists(string login, string password, out Guid userId);
        /// <summary>
        /// Регистрирует нового пользователя в системе
        /// </summary>
        Guid RegisterNewUser(string login, string password);
        /// <summary>
        /// Проверяет, занят ли указанный логин
        /// </summary>
        bool LoginIsTaken(string login);
        /// <summary>
        /// Проверяет соответствие пароля требованиям сложности
        /// </summary>
        bool ValidatePassword(string password);
        /// <summary>
        /// Проверяет соответствие логина требованиям формата
        /// </summary>
        bool ValidateLogin(string login);
        /// <summary>
        /// Получает список всех пользователей с их рейтингами
        /// </summary>
        IEnumerable<User> GetAllUsersWithRatings();
    }
}
