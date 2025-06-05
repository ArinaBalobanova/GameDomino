namespace Domino2
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            lblScore = new Label();
            imageList1 = new ImageList(components);
            flowLayoutPanelOpponent = new FlowLayoutPanel();
            flowLayoutPanelPlayer = new FlowLayoutPanel();
            lblTime = new Label();
            panelGameBoard = new Panel();
            btnPassTurn = new Button();
            btnNewGame = new Button();
            btnInvite = new Button();
            listViewRatings = new ListView();
            TimerGame = new System.Windows.Forms.Timer(components);
            lblStatus = new Label();
            listViewPlayers = new ListView();
            lblRating = new Label();
            flowLayoutPanelPlayer.SuspendLayout();
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.BackColor = Color.FromArgb(101, 76, 51);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(22, 42);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(279, 43);
            lblScore.TabIndex = 1;
            lblScore.Text = "label1";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // flowLayoutPanelOpponent
            // 
            flowLayoutPanelOpponent.BackgroundImage = (Image)resources.GetObject("flowLayoutPanelOpponent.BackgroundImage");
            flowLayoutPanelOpponent.BackgroundImageLayout = ImageLayout.Stretch;
            flowLayoutPanelOpponent.Location = new Point(324, 90);
            flowLayoutPanelOpponent.Name = "flowLayoutPanelOpponent";
            flowLayoutPanelOpponent.Size = new Size(760, 148);
            flowLayoutPanelOpponent.TabIndex = 2;
            // 
            // flowLayoutPanelPlayer
            // 
            flowLayoutPanelPlayer.BackgroundImage = (Image)resources.GetObject("flowLayoutPanelPlayer.BackgroundImage");
            flowLayoutPanelPlayer.BackgroundImageLayout = ImageLayout.Stretch;
            flowLayoutPanelPlayer.Controls.Add(lblTime);
            flowLayoutPanelPlayer.Location = new Point(324, 553);
            flowLayoutPanelPlayer.Name = "flowLayoutPanelPlayer";
            flowLayoutPanelPlayer.Size = new Size(760, 173);
            flowLayoutPanelPlayer.TabIndex = 3;
            // 
            // lblTime
            // 
            lblTime.BackColor = Color.Transparent;
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(3, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(173, 39);
            lblTime.TabIndex = 10;
            lblTime.Text = "label1";
            // 
            // panelGameBoard
            // 
            panelGameBoard.BackgroundImage = (Image)resources.GetObject("panelGameBoard.BackgroundImage");
            panelGameBoard.BackgroundImageLayout = ImageLayout.Stretch;
            panelGameBoard.Location = new Point(324, 236);
            panelGameBoard.Name = "panelGameBoard";
            panelGameBoard.Size = new Size(760, 322);
            panelGameBoard.TabIndex = 4;
            // 
            // btnPassTurn
            // 
            btnPassTurn.BackColor = Color.FromArgb(234, 208, 178);
            btnPassTurn.FlatStyle = FlatStyle.Popup;
            btnPassTurn.Location = new Point(324, 42);
            btnPassTurn.Name = "btnPassTurn";
            btnPassTurn.Size = new Size(379, 46);
            btnPassTurn.TabIndex = 5;
            btnPassTurn.Text = "Пропустить ход ";
            btnPassTurn.UseVisualStyleBackColor = false;
            btnPassTurn.Click += btnPassTurn_Click;
            // 
            // btnNewGame
            // 
            btnNewGame.BackColor = Color.FromArgb(234, 208, 178);
            btnNewGame.FlatStyle = FlatStyle.Popup;
            btnNewGame.Location = new Point(709, 42);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(375, 46);
            btnNewGame.TabIndex = 6;
            btnNewGame.Text = "Новая игра";
            btnNewGame.UseVisualStyleBackColor = false;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnInvite
            // 
            btnInvite.BackColor = Color.FromArgb(234, 208, 178);
            btnInvite.FlatStyle = FlatStyle.Popup;
            btnInvite.Location = new Point(168, 103);
            btnInvite.Name = "btnInvite";
            btnInvite.Size = new Size(121, 27);
            btnInvite.TabIndex = 7;
            btnInvite.Text = "Пригласить";
            btnInvite.UseVisualStyleBackColor = false;
            btnInvite.Click += btnInvite_Click;
            // 
            // listViewRatings
            // 
            listViewRatings.Location = new Point(22, 90);
            listViewRatings.Name = "listViewRatings";
            listViewRatings.Size = new Size(279, 286);
            listViewRatings.TabIndex = 9;
            listViewRatings.UseCompatibleStateImageBehavior = false;
            // 
            // TimerGame
            // 
            TimerGame.Tick += TimerGame_Tick;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Tan;
            lblStatus.Location = new Point(816, 746);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(257, 47);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "label1";
            // 
            // listViewPlayers
            // 
            listViewPlayers.Location = new Point(22, 442);
            listViewPlayers.Name = "listViewPlayers";
            listViewPlayers.Size = new Size(279, 286);
            listViewPlayers.TabIndex = 12;
            listViewPlayers.UseCompatibleStateImageBehavior = false;
            // 
            // lblRating
            // 
            lblRating.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblRating.Location = new Point(116, 398);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(101, 31);
            lblRating.TabIndex = 0;
            lblRating.Text = "Рейтинг";
            lblRating.Click += label1_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(1096, 780);
            Controls.Add(lblRating);
            Controls.Add(listViewPlayers);
            Controls.Add(lblStatus);
            Controls.Add(listViewRatings);
            Controls.Add(btnInvite);
            Controls.Add(btnNewGame);
            Controls.Add(btnPassTurn);
            Controls.Add(panelGameBoard);
            Controls.Add(flowLayoutPanelPlayer);
            Controls.Add(flowLayoutPanelOpponent);
            Controls.Add(lblScore);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "MainWindow";
            Text = "MainWindow";
            Load += MainWindow_Load;
            flowLayoutPanelPlayer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblScore;
        private ImageList imageList1;
        private FlowLayoutPanel flowLayoutPanelOpponent;
        private FlowLayoutPanel flowLayoutPanelPlayer;
        private Panel panelGameBoard;
        private Button btnPassTurn;
        private Button btnNewGame;
        private Button btnInvite;
        private ListView listViewRatings;
        private Label lblTime;
        private System.Windows.Forms.Timer TimerGame;
        private Label lblStatus;
        private ListView listViewPlayers;
        private Label lblRating;
    }
}