

namespace GameDomino.Game
{
    /// <summary>
    /// Представляет доминошную фишку с левым и правым значениями
    /// </summary>
    public class DominoTile
    {
        
        /// <summary>
        /// Получает значение левой части фишки
        /// </summary>
        public int LeftValue { get; }
        /// <summary>
        /// Получает значение правой части фишки
        /// </summary>
        public int RightValue { get; }
        /// <summary>
        /// Получает PictureBox, связанный с этой фишкой
        /// </summary>
        public PictureBox PictureBox { get; }
        /// <summary>
        /// Получает или устанавливает состояние переворота фишки
        /// </summary>
        public bool IsFlipped { get; private set; }
        /// <summary>
        /// Событие при нажатии мыши на фишку
        /// </summary>
        public event MouseEventHandler MouseDown;

        /// <summary>
        /// Событие при перемещении мыши с зажатой кнопкой
        /// </summary>
        public event MouseEventHandler MouseMove;

        /// <summary>
        /// Событие при отпускании кнопки мыши
        /// </summary>
        public event MouseEventHandler MouseUp;


        /// <summary>
        /// Инициализирует новую фишку домино с указанными значениями
        /// </summary>
        public DominoTile(int left, int right)
        {
            LeftValue = left;
            RightValue = right;
            PictureBox = new PictureBox
            {
                Size = new Size(60, 30),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = this
            };

            UpdateImage();

            PictureBox.MouseDown += (s, e) => MouseDown?.Invoke(s, e);
            PictureBox.MouseMove += (s, e) => MouseMove?.Invoke(s, e);
            PictureBox.MouseUp += (s, e) => MouseUp?.Invoke(s, e);
        }
        /// <summary>
        /// Переворачивает фишку (меняет местами левое и правое значения)
        /// </summary>
        public void Flip()
        {
            IsFlipped = !IsFlipped;
            UpdateImage();
        }

        private void UpdateImage()
        {

            var bmp = new Bitmap(PictureBox.Width, PictureBox.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);

                g.DrawLine(Pens.Black, PictureBox.Width / 2, 0, PictureBox.Width / 2, PictureBox.Height);

                DrawDots(g, IsFlipped ? RightValue : LeftValue, new Rectangle(0, 0, PictureBox.Width / 2, PictureBox.Height));
                DrawDots(g, IsFlipped ? LeftValue : RightValue, new Rectangle(PictureBox.Width / 2, 0, PictureBox.Width / 2, PictureBox.Height));
            }

            PictureBox.Image = bmp;
        }

        private void DrawDots(Graphics g, int value, Rectangle area)
        {

            var brush = Brushes.Black;
            var dotSize = 5;
            var centerX = area.Left + area.Width / 2;
            var centerY = area.Top + area.Height / 2;

            switch (value)
            {
                case 1:
                    g.FillEllipse(brush, centerX - dotSize / 2, centerY - dotSize / 2, dotSize, dotSize);
                    break;
                case 2:
                    g.FillEllipse(brush, area.Left + 5, area.Top + 5, dotSize, dotSize);
                    g.FillEllipse(brush, area.Right - 10, area.Bottom - 10, dotSize, dotSize);
                    break;
                case 3:
                    g.FillEllipse(brush, area.Left + 5, area.Top + 5, dotSize, dotSize);
                    g.FillEllipse(brush, centerX - dotSize / 2, centerY - dotSize / 2, dotSize, dotSize);
                    g.FillEllipse(brush, area.Right - 10, area.Bottom - 10, dotSize, dotSize);
                    break;
                case 4:
                    g.FillEllipse(brush, area.Left + 5, area.Top + 5, dotSize, dotSize);
                    g.FillEllipse(brush, area.Right - 10, area.Top + 5, dotSize, dotSize);
                    g.FillEllipse(brush, area.Left + 5, area.Bottom - 10, dotSize, dotSize);
                    g.FillEllipse(brush, area.Right - 10, area.Bottom - 10, dotSize, dotSize);
                    break;
                case 5:
                    DrawDots(g, 4, area);
                    g.FillEllipse(brush, centerX - dotSize / 2, centerY - dotSize / 2, dotSize, dotSize);
                    break;
                case 6:
                    DrawDots(g, 4, area);
                    g.FillEllipse(brush, area.Left + 5, centerY - dotSize / 2, dotSize, dotSize);
                    g.FillEllipse(brush, area.Right - 10, centerY - dotSize / 2, dotSize, dotSize);
                    break;
            }
        }
    }
}
