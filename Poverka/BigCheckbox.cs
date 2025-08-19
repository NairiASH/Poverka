using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poverka
{
    public class BigCheckbox : CheckBox
    {
        public int BoxSize { get; set; } = 18;

        public BigCheckbox()
        {
            this.Font = new Font("Segoe UI", 9F);
            this.AutoSize = false;
            this.Size = new Size(80, 6);
            this.Height = BoxSize + 6;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.Clear(this.BackColor);

            Rectangle boxRect = new Rectangle(2, (this.Height - BoxSize) / 2, BoxSize, BoxSize);

            // Состояние галочки
            ButtonState state = this.Checked ? ButtonState.Checked : ButtonState.Normal;

            ControlPaint.DrawCheckBox(pe.Graphics, boxRect, state);
        }
    }
}
