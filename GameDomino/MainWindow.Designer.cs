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
            lblScore = new Label();
            imageList1 = new ImageList(components);
            flowLayoutPanelOpponent = new FlowLayoutPanel();
            flowLayoutPanelPlayer = new FlowLayoutPanel();
            panelGameBoard = new Panel();
            btnPassTurn = new Button();
            btnNewGame = new Button();
            btnInvite = new Button();
            btnPlaceTile = new Button();
            listViewRatings = new ListView();
            lblTime = new Label();
            TimerGame = new System.Windows.Forms.Timer(components);
            lblYourTurn = new Label();
            SuspendLayout();
            // 
            // lblScore
            // 
            lblScore.Location = new Point(12, 9);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(144, 44);
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
            flowLayoutPanelOpponent.Location = new Point(324, 90);
            flowLayoutPanelOpponent.Name = "flowLayoutPanelOpponent";
            flowLayoutPanelOpponent.Size = new Size(760, 329);
            flowLayoutPanelOpponent.TabIndex = 2;
            // 
            // flowLayoutPanelPlayer
            // 
            flowLayoutPanelPlayer.Location = new Point(324, 536);
            flowLayoutPanelPlayer.Name = "flowLayoutPanelPlayer";
            flowLayoutPanelPlayer.Size = new Size(760, 190);
            flowLayoutPanelPlayer.TabIndex = 3;
            // 
            // panelGameBoard
            // 
            panelGameBoard.Location = new Point(324, 425);
            panelGameBoard.Name = "panelGameBoard";
            panelGameBoard.Size = new Size(760, 105);
            panelGameBoard.TabIndex = 4;
            // 
            // btnPassTurn
            // 
            btnPassTurn.Location = new Point(624, 46);
            btnPassTurn.Name = "btnPassTurn";
            btnPassTurn.Size = new Size(154, 29);
            btnPassTurn.TabIndex = 5;
            btnPassTurn.Text = "Пропустить ход ";
            btnPassTurn.UseVisualStyleBackColor = true;
            btnPassTurn.Click += btnPassTurn_Click;
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(784, 46);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(150, 29);
            btnNewGame.TabIndex = 6;
            btnNewGame.Text = "Новая игра";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnInvite
            // 
            btnInvite.Location = new Point(75, 194);
            btnInvite.Name = "btnInvite";
            btnInvite.Size = new Size(120, 29);
            btnInvite.TabIndex = 7;
            btnInvite.Text = "Пригласить";
            btnInvite.UseVisualStyleBackColor = true;
            btnInvite.Click += btnInvite_Click;
            // 
            // btnPlaceTile
            // 
            btnPlaceTile.Location = new Point(940, 46);
            btnPlaceTile.Name = "btnPlaceTile";
            btnPlaceTile.Size = new Size(144, 29);
            btnPlaceTile.TabIndex = 8;
            btnPlaceTile.Text = "Поставить фишку";
            btnPlaceTile.UseVisualStyleBackColor = true;
            btnPlaceTile.Click += btnPlaceTile_Click_1;
            // 
            // listViewRatings
            // 
            listViewRatings.Location = new Point(12, 404);
            listViewRatings.Name = "listViewRatings";
            listViewRatings.Size = new Size(306, 198);
            listViewRatings.TabIndex = 9;
            listViewRatings.UseCompatibleStateImageBehavior = false;
            // 
            // lblTime
            // 
            lblTime.Location = new Point(522, 771);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(538, 39);
            lblTime.TabIndex = 10;
            lblTime.Text = "label1";
            // 
            // TimerGame
            // 
            TimerGame.Tick += TimerGame_Tick;
            // 
            // lblYourTurn
            // 
            lblYourTurn.Location = new Point(504, 46);
            lblYourTurn.Name = "lblYourTurn";
            lblYourTurn.Size = new Size(62, 25);
            lblYourTurn.TabIndex = 11;
            lblYourTurn.Text = "label1";
            lblYourTurn.Click += lblYourTurn_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 819);
            Controls.Add(lblYourTurn);
            Controls.Add(lblTime);
            Controls.Add(listViewRatings);
            Controls.Add(btnPlaceTile);
            Controls.Add(btnInvite);
            Controls.Add(btnNewGame);
            Controls.Add(btnPassTurn);
            Controls.Add(panelGameBoard);
            Controls.Add(flowLayoutPanelPlayer);
            Controls.Add(flowLayoutPanelOpponent);
            Controls.Add(lblScore);
            Name = "MainWindow";
            Text = "MainWindow";
            Load += MainWindow_Load;
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
        private Button btnPlaceTile;
        private ListView listViewRatings;
        private Label lblTime;
        private System.Windows.Forms.Timer TimerGame;
        private Label lblYourTurn;
    }
}