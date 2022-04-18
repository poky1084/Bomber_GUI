using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomber_GUI.Forms
{
    public class stratGrid : Control
    {
        private Rectangle perimeterRect;

        private Rectangle[] squareRects;
        public int[] squareData { get; set; }

        private Brush idleColor = Brushes.DarkGray;
        private Brush SetecledColor = Brushes.Green;

        private int _squareSpacing;

        public int SquareSpacing
        {
            get { return _squareSpacing; }
            set
            {
                _squareSpacing = Math.Abs(value);
                Invalidate();
            }
        }

        public stratGrid()
        {

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

            Size = new Size(100, 100);
            SquareSpacing = 6;

            Reset();

        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);

            e.Graphics.Clear(Parent.BackColor);

            int index = 0;

            int squareWidth = (Width - (SquareSpacing * 6)) / 5;
            int start = (Width - (squareWidth * 5) - (SquareSpacing * 4)) / 2;

            for (int col = 0; col < 5; col++)
            {
                int y = start + (squareWidth + SquareSpacing) * col;
                for (int row = 0; row < 5; row++)
                {

                    int x = start + (squareWidth + SquareSpacing) * row;
                    squareRects[index] = new Rectangle(x, y, squareWidth, squareWidth);
                    if (squareData[index] == 1)
                    {
                        e.Graphics.FillRectangle(SetecledColor, squareRects[index]);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(idleColor, squareRects[index]);
                    }

                    index++;

                }
            }

        }

        protected override void OnSizeChanged(EventArgs e)
        {

            base.OnSizeChanged(e);

            if (Width > Height)
            {
                Height = Width;
            }
            else if (Height > Width)
            {
                Width = Height;
            }

            perimeterRect = new Rectangle(0, 0, Width - 1, Height - 1);

        }

        public void Reset()
        {

            squareRects = new Rectangle[25];
            squareData = new int[25];

            for (int i = 0; i < squareData.Length; i++) squareData[i] = 0;

            Invalidate();

        }

        public void SetValue(int index, int c)
        {
            squareData[index] = c;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            for (int i = 0; i < squareRects.Length; i++)
            {
                if (squareRects[i].Contains(e.Location))
                {
                    if (squareData[i] == 0)
                        SetValue(i, 1);
                    else
                        SetValue(i, 0);
                }
            }
        }
    }
}
