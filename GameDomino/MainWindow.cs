using GameDomino;
using GameDomino.Game;
using NLog;


namespace Domino2
{/// <summary>
 /// класс формы главного окна
 /// </summary>
    public partial class MainWindow : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IDominoGameService _gameService;
        private readonly IUserService _userService;
        private Guid _userId;
        private bool _isDragging;
        private DominoTile _draggedTile;
        private Point _dragStart;
        private System.Windows.Forms.Timer _gameTimer;
        
        /// <summary>
        /// конструктор формы главного окна
        /// </summary>
        public MainWindow(Guid userId, IDominoGameService gameService, IUserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _gameService = gameService;
            _userService = userService;

            SetupGame();
            
        }
        public void SetUserId(Guid userId)
        {
            _userId = userId;

        }

        private async void SetupGame()
        {
            _gameTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            _gameTimer.Tick += TimerGame_Tick;

            _gameService.GameEvent += OnGameEvent;

            await _gameService.StartGameAsync();
            await UpdateGameStateAsync();

            _gameTimer.Start();
        }

        private async void TimerGame_Tick(object sender, EventArgs e)
        {
            await _gameService.PassTurnAsync();
            await UpdateGameStateAsync();
        }

        private async void OnGameEvent(object sender, GameEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnGameEvent(sender, e)));
                return;
            }

            switch (e.EventType)
            {
                case GameEventType.TurnChanged:
                    lblStatus.Text = e.Message;
                    break;
                case GameEventType.TilePlaced:
                    await UpdateGameStateAsync();
                    break;
                case GameEventType.GameOver:
                    _gameTimer.Stop();
                    MessageBox.Show(e.Message);
                    break;
            }
        }

        private async Task UpdateGameStateAsync()
        {
            var playerTiles = await _gameService.GetPlayerTilesAsync();
            var opponentTiles = await _gameService.GetOpponentTilesAsync();
            var leftEndTile = await _gameService.GetLeftEndTileAsync();
            var rightEndTile = await _gameService.GetRightEndTileAsync();

            UpdatePlayerTiles(playerTiles);
            UpdateOpponentTiles(opponentTiles);
            UpdateBoard(leftEndTile, rightEndTile);
        }

        private void UpdatePlayerTiles(List<DominoTile> tiles)
        {
            flowLayoutPanelPlayer.Controls.Clear();
            foreach (var tile in tiles)
            {
                tile.MouseDown += Tile_MouseDown;
                tile.MouseMove += Tile_MouseMove;
                tile.MouseUp += Tile_MouseUp;
                flowLayoutPanelPlayer.Controls.Add(tile.PictureBox);
            }
        }

        private void UpdateOpponentTiles(List<DominoTile> tiles)
        {
            flowLayoutPanelOpponent.Controls.Clear();
            foreach (var tile in tiles)
            {
                var hiddenTile = new PictureBox
                {
                    Size = new Size(60, 30),
                    BackColor = Color.LightGray,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = tile
                };
                flowLayoutPanelOpponent.Controls.Add(hiddenTile);
            }
        }

        private void UpdateBoard(DominoTile leftEndTile, DominoTile rightEndTile)
        {
            panelGameBoard.Controls.Clear();

            if (leftEndTile != null)
            {
                leftEndTile.PictureBox.Location = new Point(10, panelGameBoard.Height / 2 - 15);
                panelGameBoard.Controls.Add(leftEndTile.PictureBox);
            }

            if (rightEndTile != null && rightEndTile != leftEndTile)
            {
                rightEndTile.PictureBox.Location = new Point(panelGameBoard.Width - 70, panelGameBoard.Height / 2 - 15);
                panelGameBoard.Controls.Add(rightEndTile.PictureBox);
            }
        }

        private void Tile_MouseDown(object sender, MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (pictureBox?.Tag is DominoTile tile)
            {
                _isDragging = true;
                _draggedTile = tile;
                _dragStart = e.Location;
                pictureBox.BringToFront();
            }
            logger.Fatal("При зажатии мышкой фишки, она начиниает логать");
        }

        private void Tile_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragging || _draggedTile == null) return;

            var pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.Left += e.X - _dragStart.X;
                pictureBox.Top += e.Y - _dragStart.Y;
            }
            logger.Fatal("Проблемы с перемещением фишек");
        }

        private async void Tile_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isDragging || _draggedTile == null) return;

            _isDragging = false;
            var pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                var boardRect = panelGameBoard.RectangleToScreen(panelGameBoard.ClientRectangle);
                var tileRect = pictureBox.RectangleToScreen(pictureBox.ClientRectangle);

                if (boardRect.IntersectsWith(tileRect))
                {

                    var leftDistance = Math.Abs(tileRect.Left - boardRect.Left);
                    var rightDistance = Math.Abs(tileRect.Right - boardRect.Right);
                    var placeToLeft = leftDistance < rightDistance;

                    var isValid = await _gameService.IsValidMoveAsync(_draggedTile, placeToLeft);
                    if (isValid)
                    {
                        var success = await _gameService.PlaceTileAsync(_draggedTile, placeToLeft);
                        if (success)
                        {
                            await UpdateGameStateAsync();
                            return;
                        }
                    }
                }


                var tileIndex = flowLayoutPanelPlayer.Controls.IndexOf(pictureBox);
                if (tileIndex >= 0)
                {
                    flowLayoutPanelPlayer.Controls.SetChildIndex(pictureBox, tileIndex);
                }
            }
        }

        private async void btnPassTurn_Click(object sender, EventArgs e)
        {
            await _gameService.PassTurnAsync();
            await UpdateGameStateAsync();
            logger.Error("Не видно, что ользователь пропустил ход");
        }

        private async void btnNewGame_Click(object sender, EventArgs e)
        {
            await _gameService.StartGameAsync();
            await UpdateGameStateAsync();
            _gameTimer.Start();
            logger.Info("Пользователь начал новую игру");
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _gameTimer?.Stop();
            _gameService.GameEvent -= OnGameEvent;
            base.OnFormClosed(e);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            var inviteForm = new InviteForm(Program.Container.Resolve<IUserService>());
            inviteForm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}