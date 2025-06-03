using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    /// <summary>
    /// Класс для локализации
    /// </summary>
    public static class LanguageManager
    {
        public static event Action LanguageChanged;

        public static void SetLanguage(string languageCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCode);
            LanguageChanged?.Invoke();
        }
    }
}
