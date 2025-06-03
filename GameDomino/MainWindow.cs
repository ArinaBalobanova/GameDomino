
using Domino;
using GameDomino;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino2
{
    public partial class MainWindow : Form
    {
        private Guid _userId;
        private readonly IUserService _userService;
        private readonly DominoGame _game;
        private readonly List<PictureBox> _playerTiles = new List<PictureBox>();
        private readonly List<PictureBox> _opponentTiles = new List<PictureBox>();
        private readonly System.Windows.Forms.Timer _timer;


        public Guid UserId { get; private set; }
        public MainWindow(Guid userId)
        {
            InitializeComponent();
            UserId = userId;
            _userService = Program.Container.Resolve<IUserService>();
            _game = new DominoGame();

            _timer = new System.Windows.Forms.Timer { Interval = 1000 };
            _timer.Tick += TimerGame_Tick;

            _game.PlayerTurnChanged += Game_PlayerTurnChanged;

            InitializePlayerTiles();
            InitializeOpponentTiles();
            InitializeComponent();
            UserId = userId;
            _userService = Program.Container.Resolve<IUserService>();
            _game = new DominoGame();

            LoadUserRatings();

            StartGame();
        }
        private void InitializePlayerTiles()
        {
            for (int i = 0; i < 7; i++)
            {
                var tile = new PictureBox
                {
                    Width = 50,
                    Height = 30,
                    Margin = new Padding(5),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.FixedSingle,

                };
                Click += PlayerTile_Click;
                flowLayoutPanelPlayer.Controls.Add(tile);
                _playerTiles.Add(tile);
            }
        }
        private void InitializeOpponentTiles()
        {
            for (int i = 0; i < 7; i++)
            {
                var tile = new PictureBox
                {
                    Width = 50,
                    Height = 30,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle
                };
                flowLayoutPanelOpponent.Controls.Add(tile);
                _opponentTiles.Add(tile);
            }
        }
        private void LoadUserRatings()
        {
            var users = _userService.GetAllUsersWithRatings();
            listViewRatings.Items.Clear();

            foreach (var user in users)
            {
                var item = new ListViewItem(user.Login);
                item.SubItems.Add(user.Rating.ToString());
                listViewRatings.Items.Add(item);
            }
        }
        private void StartGame()
        {
            _game.StartGame();
            UpdateUI();
            _timer.Start();
        }
        private void UpdateUI()
        {
            lblScore.Text = $"Счёт: {_game.PlayerScore}:{_game.OpponentScore}";
            lblTime.Text = $"Оставшееся время: {_game.RemainingTime} сек.";
            lblYourTurn.Visible = _game.IsPlayerTurn;

            for (int i = 0; i < _playerTiles.Count; i++)
            {
                if (i < _game.PlayerTiles.Count)
                {
                    _playerTiles[i].Image = GetTileImage(_game.PlayerTiles[i]);
                    _playerTiles[i].Visible = true;
                }
                else
                {
                    _playerTiles[i].Visible = false;
                }
            }

            for (int i = 0; i < _opponentTiles.Count; i++)
            {
                if (i < _game.OpponentTiles.Count)
                {
                    _opponentTiles[i].Image = GetTileImage(_game.OpponentTiles[i]);
                    _opponentTiles[i].Visible = true;
                }
                else
                {
                    _opponentTiles[i].Visible = false;
                }
            }
        }

        private Image GetTileImage(int[] tile)
        {

            var image = new Bitmap(50, 30);
            using var g = Graphics.FromImage(image);
            g.FillRectangle(Brushes.White, 0, 0, 50, 30);

            DrawDots(g, tile[0], new Point(10, 10));
            DrawDots(g, tile[1], new Point(40, 10));

            return image;
        }
        private void DrawDots(Graphics graphics, int number, Point position)
        {
            var brush = Brushes.Black;
            switch (number)
            {
                case 0:
                    break;
                case 1:
                    graphics.FillEllipse(brush, position.X + 20, position.Y + 10, 5, 5);
                    break;
                case 2:
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 5, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 25, 5, 5);
                    break;
                case 3:
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 5, 5, 5);
                    graphics.FillEllipse(brush, position.X + 20, position.Y + 10, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 25, 5, 5);
                    break;
                case 4:
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 5, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 5, 5, 5);
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 25, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 25, 5, 5);
                    break;
                case 5:
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 5, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 5, 5, 5);
                    graphics.FillEllipse(brush, position.X + 20, position.Y + 10, 5, 5);
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 25, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 25, 5, 5);
                    break;
                case 6:
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 5, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 5, 5, 5);
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 15, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 15, 5, 5);
                    graphics.FillEllipse(brush, position.X + 5, position.Y + 25, 5, 5);
                    graphics.FillEllipse(brush, position.X + 35, position.Y + 25, 5, 5);
                    break;
            }
        }
        private void Game_PlayerTurnChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnPlaceTile_Click(object sender, EventArgs e)
        {

            _game.PlaceTile();
            UpdateUI();
        }
        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void btnPassTurn_Click(object sender, EventArgs e)
        {
            _game.PassTurn();
            UpdateUI();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            _game.StartGame();
            UpdateUI();
        }

        private void btnPlaceTile_Click_1(object sender, EventArgs e)
        {

        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            var inviteForm = Program.Container.Resolve<InviteForm>();
            inviteForm.Show();
            this.Hide();
        }

        private void TimerGame_Tick(object sender, EventArgs e)
        {
            _game.UpdateTimer();
            UpdateUI();

            if (_game.GameOver)
            {
                _timer.Stop();
                MessageBox.Show("Игра окончена!");
                /*Close()*/;
            }
        }
        private void PlayerTile_Click(object sender, EventArgs e)
        {
            var tilePictureBox = (PictureBox)sender;
            var index = _playerTiles.IndexOf(tilePictureBox);

            if (index >= 0 && index < _game.PlayerTiles.Count)
            {
                _game.SelectTile(index);
                UpdateUI();
            }
        }

        private void lblYourTurn_Click(object sender, EventArgs e)
        {

        }
    }
}
