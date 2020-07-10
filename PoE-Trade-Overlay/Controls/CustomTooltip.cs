using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class CustomTooltip : ToolTip
    {
        public CustomTooltip()
        {
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);
        }

        private void OnPopup(object sender, PopupEventArgs e)
        {
            Graphics g = e.AssociatedControl.CreateGraphics();
            CustomTooltip tip = (CustomTooltip)sender;
            Font f = new Font("Segoe UI", 10f);
            SizeF size = g.MeasureString(this.GetToolTip(e.AssociatedControl), f, 350);
            e.ToolTipSize = new Size(350, (int)size.Height);
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush b = new SolidBrush(Color.FromArgb(14, 15, 16));
            SizeF size = g.MeasureString(e.ToolTipText, e.Font, e.Bounds.Width);

            g.FillRectangle(b, e.Bounds);

            g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(90, 56, 6)), 1), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));

            RectangleF r = new RectangleF(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 1, e.Bounds.Height - 1);

            g.DrawString(e.ToolTipText, e.Font, Brushes.White, r);

            b.Dispose();
        }
    }
}