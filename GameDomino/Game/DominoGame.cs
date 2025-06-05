

namespace GameDomino.Game
{
    /// <summary>
    /// Класс логики игры
    /// </summary>
    public class DominoGame
    {
        public event EventHandler PlayerTurnChanged;

        public bool IsPlayerTurn { get; private set; } = true;
        public int PlayerScore { get; private set; }
        public int OpponentScore { get; private set; }
        public int RemainingTime { get; private set; } = 60;
        public bool GameOver { get; private set; }


        public List<int[]> PlayerTiles { get; private set; }
        public List<int[]> OpponentTiles { get; private set; }

        public DominoGame()
        {
            PlayerTiles = GenerateTiles();
            OpponentTiles = GenerateTiles();
          
        }
        public void StartGame()
        {
            IsPlayerTurn = true;
            PlayerScore = 0;
            OpponentScore = 0;
            RemainingTime = 60;
            GameOver = false;

        }

        public void UpdateTimer()
        {
            RemainingTime--;
            if (RemainingTime <= 0)
            {
                GameOver = true;
            }
        }

        public void PlaceTile()
        {
            if (IsPlayerTurn)
            {
                
                IsPlayerTurn = false;
                OnPlayerTurnChanged();
            }
            else
            {
                IsPlayerTurn = true;
                OnPlayerTurnChanged();
            }
        }

        public void PassTurn()
        {
            
            IsPlayerTurn = !IsPlayerTurn;
            OnPlayerTurnChanged();
        }

        public void SelectTile(int index)
        {
            
            if (index >= 0 && index < PlayerTiles.Count)
            {
               
                SelectedTileIndex = index;
            }
        }

        private int? SelectedTileIndex { get; set; }

        private void OnPlayerTurnChanged()
        {
            PlayerTurnChanged?.Invoke(this, EventArgs.Empty);
        }

        private List<int[]> GenerateTiles()
        {
            
            var tiles = new List<int[]>();
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                tiles.Add(new[] { random.Next(7), random.Next(7) });
            }
            return tiles;
        }
    }
}
