using System;
using System.Collections.Generic;
using System.Linq;


namespace GameDomino.Game
{
    /// <summary>
    /// Представляет аргументы игрового события
    /// </summary>
    public class GameEventArgs : EventArgs
    {
        /// <summary>
        /// Получает сообщение, связанное с событием
        /// </summary>
        public string Message { get; }
        /// <summary>
        /// Получает тип игрового события
        /// </summary>
        public GameEventType EventType { get; }

        /// <summary>
        /// Инициализирует новый экземпляр GameEventArgs
        /// </summary>
        public GameEventArgs(string message, GameEventType eventType)
        {
            Message = message;
            EventType = eventType;
        }
    }
}
