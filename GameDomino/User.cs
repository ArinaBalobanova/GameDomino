using System.Text.RegularExpressions;

namespace Domino
{
    /// <summary>
    /// класс пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// Рейтинг игрока
        /// </summary>
        public int Rating { get; set; }   
       
    }
}