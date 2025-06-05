

namespace GameDomino.Game
{
    /// <summary>
    /// Определяет контракт для сервиса игры в домино
    /// </summary>
    public interface IDominoGameService
    {
        /// <summary>
        /// Событие, возникающее при игровых событиях
        /// </summary>
        event EventHandler<GameEventArgs> GameEvent;
        /// <summary>
        /// Начинает новую игру
        /// </summary>
        Task StartGameAsync();
        /// <summary>
        /// Размещает фишку на игровом поле
        /// </summary>
        Task<bool> PlaceTileAsync(DominoTile tile, bool toLeft);
        /// <summary>
        /// Пропускает текущий ход
        /// </summary>
        Task PassTurnAsync();
        /// <summary>
        /// Получает фишки игрока
        /// </summary>
        Task<List<DominoTile>> GetPlayerTilesAsync();
        /// <summary>
        /// Получает фишки противника
        /// </summary>
        Task<List<DominoTile>> GetOpponentTilesAsync();
        /// <summary>
        /// Получает крайнюю левую фишку на поле
        /// </summary>
        Task<DominoTile> GetLeftEndTileAsync();
        /// <summary>
        /// Получает крайнюю правую фишку на поле
        /// </summary>
        Task<DominoTile> GetRightEndTileAsync();
        /// <summary>
        /// Проверяет, является ли ход допустимым
        /// </summary>
        Task<bool> IsValidMoveAsync(DominoTile tile, bool toLeft);
    }
}
