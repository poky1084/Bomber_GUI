using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber_GUI.Forms
{
    public class SatoshiGrid : Control
    {
        private Graphics g;
        private int squareSide = 0;
        private int space = 5;
        private int gridSides = 5;
        private Brush[] squareData;
        private int borderSize = 0;
        private Brush IdleColor = Brushes.DarkGray;
        public bool SquareBorder { get; set; }
        public bool GridBorder { get; set; }

        public SatoshiGrid()
        {
            g = this.CreateGraphics();
            RecaclulateSizes();
            squareData = new Brush[gridSides * gridSides];
            for (int i = 0; i < squareData.Length; i++)
                squareData[i] = IdleColor;
        }

        public void IdleSquare(int square)
        {
            squareData[square] = IdleColor;
            this.Invalidate();
        }

        public bool IsIdle(int square)
        {
            return squareData[square] == IdleColor;
        }

        public void Reset()
        {
            for (int i = 0; i < squareData.Length; i++)
                squareData[i] = IdleColor;
            this.Invalidate();
        }
        public void SetSquare(int square, Brush color)
        {
            squareData[square] = color;
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            if (this.Height < 1)
                this.Height = 1;
            if (this.Width < 1)
                this.Width = 1;
            if (this.Width < this.Height)
                this.Height = this.Width;
            else
                this.Width = this.Height;
            base.OnResize(e);
            RecaclulateSizes();
            g = this.CreateGraphics();
        }

        private void RecaclulateSizes()
        {
            int single_square = ((this.Height - 1) / gridSides);
            space = single_square / 9;
            squareSide = single_square - space;
            borderSize = single_square / 9;
        }

        public void PaintSquares()
        {
            int index = 0;
            Size sSize = new Size(squareSide, squareSide);
            for (int col = 0; col < gridSides; col++)
            {
                for (int row = 0; row < gridSides; row++)
                {
                    if (squareData[index] == null)
                        continue;
                    Point location = new Point((row * (squareSide + space)) + space, (col * (squareSide + space)) + space);
                    if (SquareBorder)
                    {
                        g.FillRectangle(Brushes.Black, new Rectangle(location, sSize));
                        g.FillRectangle(squareData[index], new Rectangle(new Point(location.X + (borderSize / 2), location.Y + (borderSize / 2)), new Size(sSize.Width - borderSize, sSize.Height - borderSize)));
                    }
                    else
                    {
                        g.FillRectangle(squareData[index], new Rectangle(location, sSize));
                    }
                    index++;
                }
            }
            if (GridBorder)
                g.DrawRectangle(Pens.Black, new Rectangle(new Point(0, 0), new Size(this.Height - 1, this.Width - 1)));
            //Debug.WriteLine("Paint");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintSquares();
            base.OnPaint(e);

        }
    }
}
