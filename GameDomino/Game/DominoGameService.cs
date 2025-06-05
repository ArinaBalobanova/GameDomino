

namespace GameDomino.Game
{
    /// <summary>
    /// Реализация сервиса для игры в домино
    /// </summary>

    public class DominoGameService : IDominoGameService
    {
        private readonly List<DominoTile> _allTiles;
        private readonly List<DominoTile> _playerTiles;
        private readonly List<DominoTile> _opponentTiles;
        private readonly List<DominoTile> _boardTiles;
        private bool _isPlayerTurn;
        private int _playerScore;
        private int _opponentScore;
        private int _remainingTime;
        private bool _gameOver;
        /// <summary>
        /// Событие, возникающее при игровых событиях
        /// </summary>
        public event EventHandler<GameEventArgs> GameEvent;
        /// <summary>
        /// Инициализирует новый экземпляр сервиса игры в домино
        /// </summary>
        public DominoGameService()
        {
            _allTiles = GenerateAllTiles();
            _playerTiles = new List<DominoTile>();
            _opponentTiles = new List<DominoTile>();
            _boardTiles = new List<DominoTile>();
        }
        /// <summary>
        /// Начинает новую игру
        /// </summary>
        public async Task StartGameAsync()
        {
            await Task.Run(() =>
            {
                
                var random = new Random();
                var shuffledTiles = _allTiles.OrderBy(x => random.Next()).ToList();

                _playerTiles.Clear();
                _opponentTiles.Clear();
                _boardTiles.Clear();

                for (int i = 0; i < 7; i++)
                {
                    _playerTiles.Add(shuffledTiles[i]);
                    _opponentTiles.Add(shuffledTiles[i + 7]);
                }

                var playerHasDoubleSix = _playerTiles.Any(t => t.LeftValue == 6 && t.RightValue == 6);
                var opponentHasDoubleSix = _opponentTiles.Any(t => t.LeftValue == 6 && t.RightValue == 6);

                _isPlayerTurn = playerHasDoubleSix || !opponentHasDoubleSix && random.Next(2) == 0;
                _playerScore = 0;
                _opponentScore = 0;
                _remainingTime = 60;
                _gameOver = false;

                OnGameEvent(new GameEventArgs("Игра началась!", GameEventType.TurnChanged));
            });
        }
        /// <summary>
        /// Размещает фишку на игровом поле
        /// </summary>
        public async Task<bool> PlaceTileAsync(DominoTile tile, bool toLeft)
        {
            return await Task.Run(() =>
            {
                if (!_isPlayerTurn || _gameOver) return false;

                var endTile = toLeft ? _boardTiles.FirstOrDefault() : _boardTiles.LastOrDefault();
                var endValue = toLeft ? endTile?.LeftValue : endTile?.RightValue;

                if (endTile == null || tile.LeftValue == endValue || tile.RightValue == endValue)
                {
                    
                    if (endTile != null && tile.LeftValue != endValue && tile.RightValue != endValue)
                    {
                        return false;
                    }

                    if (endTile != null)
                    {
                        if (toLeft && tile.RightValue != endValue)
                        {
                            tile.Flip();
                        }
                        else if (!toLeft && tile.LeftValue != endValue)
                        {
                            tile.Flip();
                        }
                    }

                    if (toLeft)
                    {
                        _boardTiles.Insert(0, tile);
                    }
                    else
                    {
                        _boardTiles.Add(tile);
                    }

                    _playerTiles.Remove(tile);

                    var tileSum = tile.LeftValue + tile.RightValue;
                    _playerScore += tileSum;

                    _isPlayerTurn = false;
                    OnGameEvent(new GameEventArgs("Фишка размещена", GameEventType.TilePlaced));
                    OnGameEvent(new GameEventArgs("Ход противника", GameEventType.TurnChanged));

                    if (_playerTiles.Count == 0)
                    {
                        _gameOver = true;
                        OnGameEvent(new GameEventArgs("Игрок победил!", GameEventType.GameOver));
                    }

                    return true;
                }

                return false;
            });
        }
        /// <summary>
        /// Пропускает текущий ход
        /// </summary>
        public async Task PassTurnAsync()
        {
            await Task.Run(() =>
            {
                if (_gameOver) return;

                _isPlayerTurn = !_isPlayerTurn;
                OnGameEvent(new GameEventArgs(
                    _isPlayerTurn ? "Ваш ход" : "Ход противника",
                    GameEventType.TurnChanged));
            });
        }
        /// <summary>
        /// Получает фишки игрока
        /// </summary>
        public async Task<List<DominoTile>> GetPlayerTilesAsync()
        {
            return await Task.FromResult(new List<DominoTile>(_playerTiles));
        }
        /// <summary>
        /// Получает фишки противника
        /// </summary>
        public async Task<List<DominoTile>> GetOpponentTilesAsync()
        {
            return await Task.FromResult(new List<DominoTile>(_opponentTiles));
        }
        /// <summary>
        /// Получает крайнюю левую фишку на поле
        /// </summary>
        public async Task<DominoTile> GetLeftEndTileAsync()
        {
            return await Task.FromResult(_boardTiles.FirstOrDefault());
        }
        /// <summary>
        /// Получает крайнюю правую фишку на поле
        /// </summary>
        public async Task<DominoTile> GetRightEndTileAsync()
        {
            return await Task.FromResult(_boardTiles.LastOrDefault());
        }
        /// <summary>
        /// Проверяет, является ли ход допустимым
        /// </summary>
        public async Task<bool> IsValidMoveAsync(DominoTile tile, bool toLeft)
        {
            return await Task.Run(() =>
            {
                var endTile = toLeft ? _boardTiles.FirstOrDefault() : _boardTiles.LastOrDefault();
                var endValue = toLeft ? endTile?.LeftValue : endTile?.RightValue;

                return endTile == null || tile.LeftValue == endValue || tile.RightValue == endValue;
            });
        }

        private List<DominoTile> GenerateAllTiles()
        {
            var tiles = new List<DominoTile>();
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    tiles.Add(new DominoTile(i, j));
                }
            }
            return tiles;
        }

        protected virtual void OnGameEvent(GameEventArgs e)
        {
            GameEvent?.Invoke(this, e);
        }
    }
}
