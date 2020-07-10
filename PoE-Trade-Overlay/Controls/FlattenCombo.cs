using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class FlattenCombo : ComboBox
    {
        private Color _borderColor = Color.Black;
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private Brush BorderBrush;
        private string text;

        public Color Arrow_Active { get; set; }
        public Color Arrow_Inactive { get; set; }

        public Color BackColorBase { get; set; }
        public Color BackColorButton { get; set; }
        public Color ForeColorDrop { get; set; }

        private DataTable data;

        public DataTable Data
        {
            get { return data; }
            set { data = value; }
        }

        public int column = 1;

        // Ignore MouseWheel
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0xf:
                    Graphics g = this.CreateGraphics();
                    Pen p = new Pen(Color.Black);
                    BorderBrush = new SolidBrush(BackColorBase);
                    SolidBrush buttonBack = new SolidBrush(BackColorButton);
                    SolidBrush ArrowBrush;
                    g.FillRectangle(BorderBrush, this.ClientRectangle);
                    Font font = new Font(new FontFamily("Microsoft Sans Serif"), 9);

                    if (this.SelectedIndex != -1)
                        text = this.Items[this.SelectedIndex].ToString();

                    g.DrawString(text, this.Font, new SolidBrush(ForeColorDrop), new PointF(2, 2));

                    //Draw the background of the dropdown button
                    Rectangle rect = new Rectangle(this.Width - 17, 0, 17, this.Height);
                    g.FillRectangle(buttonBack, rect);

                    //Create the path for the arrow
                    System.Drawing.Drawing2D.GraphicsPath pth = new System.Drawing.Drawing2D.GraphicsPath();
                    PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                    PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                    PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
                    pth.AddLine(TopLeft, TopRight);
                    pth.AddLine(TopRight, Bottom);

                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    //Determine the arrow's color.
                    if (this.DroppedDown)
                    {
                        ArrowBrush = new SolidBrush(Arrow_Active);
                    }
                    else
                    {
                        ArrowBrush = new SolidBrush(Arrow_Inactive);
                    }

                    //Draw the arrow
                    g.FillPath(ArrowBrush, pth);

                    break;

                default:
                    break;
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(); // causes control to be redrawn
            }
        }

        [Category("Appearance")]
        public ButtonBorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                _borderStyle = value;
                Invalidate();
            }
        }

        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}