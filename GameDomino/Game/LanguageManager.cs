
using System.Globalization;


namespace GameDomino.Game
{
    /// <summary>
    /// Класс для локализации
    /// </summary>
    public static class LanguageManager
    {
        /// <summary>
        /// Событие, возникающее при смене языка
        /// </summary>
        public static event Action LanguageChanged;
        /// <summary>
        /// Устанавливает текущий язык приложения
        /// </summary>
        public static void SetLanguage(string languageCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
            LanguageChanged?.Invoke();
        }
    }
}
