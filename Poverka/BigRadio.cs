using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Poverka
{
    public class BigRadioButton : RadioButton
    {
        public int CircleSize { get; set; } = 18;

        public Color SelectedBackgroundColor { get; set; } = Color.White;
        public Color BorderColor { get; set; } = Color.Black;
        public Color DotColor { get; set; } = Color.Black;

        public BigRadioButton()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.AutoSize = false;
            this.Height = CircleSize + 10;
            this.Width = 150;
            this.Font = new Font("Segoe UI", 9F);
        }        

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.BackColor);

            RectangleF circleRect = new RectangleF(2, (this.Height - CircleSize) / 2f, CircleSize, CircleSize);

            // Рисуем фон круга (цвет выбора или цвет формы)
            using (Brush fill = new SolidBrush(this.Enabled? SelectedBackgroundColor: this.BackColor))
            {
                e.Graphics.FillEllipse(fill, circleRect);
            }

            // Рисуем обводку круга
            using (Pen pen = new Pen(BorderColor, 1.5f))
            {
                e.Graphics.DrawEllipse(pen, circleRect);
            }

            // Рисуем внутреннюю точку, если выбран
            if (this.Checked)
            {
                float dotSize = CircleSize / 2f;
                RectangleF dotRect = new RectangleF(
                    circleRect.X + (CircleSize - dotSize) / 2f,
                    circleRect.Y + (CircleSize - dotSize) / 2f,
                    dotSize, dotSize);

                using (Brush dotBrush = new SolidBrush(DotColor))
                {
                    e.Graphics.FillEllipse(dotBrush, dotRect);
                }
            }
        }

        //public void MakeGrey()
        //{ 
        //    this.BackColor = 
        //}

        //public void MakeWhite()
        //{

        //}
    }
}
