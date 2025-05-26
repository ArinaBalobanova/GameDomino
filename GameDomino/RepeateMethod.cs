using System;
using System.Security.Cryptography;
using System.Text;

namespace Domino
{
    /// <summary>
    /// повтор методов
    /// </summary>
    public static class RepeateMethod
    {
        /// <summary>
        /// хэширование
        /// </summary>
        public static string Hashing(string password)
        {
            using MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hash);
        }
        /// <summary>
        /// Показ пароля
        /// </summary>
        public static void TogglePasswordVisibility(TextBox textBoxPassword, bool isVisible)
        {
            if (isVisible)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
            }
            textBoxPassword.Refresh();
        }
    }
}