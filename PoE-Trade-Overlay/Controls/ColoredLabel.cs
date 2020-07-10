using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PoE_Trade_Overlay.Controls
{
    public partial class ColoredLabel : UserControl
    {
        public List<LabelColor> Labels = new List<LabelColor>();

        public ColoredLabel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Font f = new Font("Lucida Console", 10);
            Graphics g = e.Graphics;

            int height = 10;

            foreach(LabelColor lbl in Labels)
            {
                int h = TextRenderer.MeasureText(lbl.Text, lbl.GetFont).Height;
                if (height < h)
                    height = h;
            }
            Height = height - 2;

            if (Labels.Count == 0)
                g.DrawString("Placeholder Text", f, new SolidBrush(Color.White), 1, 0);

            int x = 1;
            foreach(LabelColor label in Labels) 
            { 

                g.DrawString(label.Text, label.GetFont, new SolidBrush(label.Color), x, 0);
                x += TextRenderer.MeasureText(label.Text, label.GetFont).Width - 3;
            }

            // Rectangle to display control boundaries
            //g.DrawRectangle(new Pen(Color.Gray, 2f), new Rectangle(0, 0, Width, Height));
        }
    }

    public class LabelColor
    {
        public string Text;
        public float FontSize;
        public string Font = "Consolas";
        public Color Color;

        public LabelColor(string _Text, Color _Color, float _FontSize = 10, string _Font = "Consolas")
        {
            Text = _Text;
            Color = _Color;
            Font = _Font;
            FontSize = _FontSize;
        }

        public Font GetFont
        {
            get { return new Font(Font, FontSize); }
        }
    }
}