using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public enum ColorMode
    {
        Switch,
        Follow,
        Lerp
    }

    public enum KnobStyle
    {
        Image,
        Circle,
        Box
    }

    public partial class Toggle : UserControl
    {
        [Category("Color"), Description("Color of the Bar while true")]
        public Color Bar_Off { get; set; } = Color.FromArgb(16, 16, 16);

        [Category("Color"), Description("Color of the Bar while false")]
        public Color Bar_On { get; set; } = Color.FromArgb(34, 31, 31);

        [Category("Color"), Description("Color of the Border while true")]
        public Color Border_On { get; set; } = Color.FromArgb(16, 16, 16);

        [Category("Color"), Description("Color of the Border while false")]
        public Color Border_Off { get; set; } = Color.FromArgb(34, 31, 31);

        [Category("Color"), Description("Color of the Bar while false")]
        public Color KnobColor { get; set; } = Color.White;

        private string caption;

        [Category("Data"), Description("Color of the Bar while false")]
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                SetWidth();
            }
        }

        public event EventHandler OnToggle;

        private bool on;

        [Category("Data"), Description("Is the Toggle on ?")]
        public bool On
        {
            get { return on; }
            set
            {
                on = value;
                onToggle();
            }
        }

        [Category("Data"), Description("Text is left ?")]
        public bool TextIsLeft { get; set; } = true;

        private void onToggle()
        {
            if (this.OnToggle != null)
                OnToggle(this, new EventArgs());
        }

        [Category("Data"), Description("TEST")]
        public KnobStyle KnobStyle { get; set; } = KnobStyle.Circle;

        [Category("Data"), Description("ColorMode")]
        public ColorMode ColorMode { get; set; } = ColorMode.Follow;

        [Category("Data"), Description("Radius")]
        public int BorderRadius { get; set; } = 5;

        [Category("Data"), Description("ToggleSpeed")]
        public int ToggleSpeed { get; set; } = 5;

        private int spacing = 0;

        [Category("Data"), Description("Space Between Text and Toggle")]
        public int Spacing
        {
            get
            {
                return spacing;
            }
            set
            {
                spacing = value;
                SetWidth();
            }
        }

        [Category("Data"), Description("Radius")]
        public Image KnobImage { get; set; }

        [Category("Data"), Description("Radius")]
        public Image KnobImageOn { get; set; }

        [Category("Data"), Description("Radius")]
        public Size KnobSize { get; set; } = new Size(20, 20);

        [Category("Data"), Description("Radius")]
        public Size BarSize { get; set; } = new Size(40, 10);

        private BackgroundWorker worker = null;

        private int KnobX = 0;
        private int KnobXOffset = 0;
        private int TextWidth;

        public Toggle()
        {
            InitializeComponent();
            SetWidth();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            this.HandleCreated += handleCreated;
            this.Click += Slider_Click;
        }

        private void SetWidth()
        {
            Size s = TextRenderer.MeasureText(caption, this.Font);
            this.Width = BarSize.Width + 13 + s.Width + Spacing;
            TextWidth = s.Width;
            if (TextIsLeft)
                KnobXOffset = TextWidth + spacing;
            else
                KnobXOffset = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            TextWidth = TextRenderer.MeasureText(caption, this.Font).Width;
            Graphics g = e.Graphics;
            SolidBrush b_on = new SolidBrush(Bar_On);
            SolidBrush b_off = new SolidBrush(Bar_Off);
            SolidBrush Knob = new SolidBrush(KnobColor);
            int y = (this.Height - BarSize.Height) / 2;
            int x = 1;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (TextIsLeft)
                x = TextWidth + spacing;

            if (TextIsLeft)
                KnobXOffset = TextWidth + spacing;
            else
                KnobXOffset = 0;

            Rectangle rect_Fill = new Rectangle(x - 1, y, BarSize.Width, BarSize.Height);
            Rectangle rect_Border = new Rectangle(x, y, BarSize.Width, BarSize.Height);

            if (ColorMode == ColorMode.Switch)
            {
                GraphicExtensions.FillRoundedRectangle(g, (On) ? b_on : b_off, rect_Fill, BorderRadius);
                GraphicExtensions.DrawRoundedRectangle(g, new Pen((On) ? Border_On : Border_Off), rect_Border, BorderRadius);
            }
            else if (ColorMode == ColorMode.Follow)
            {
                Rectangle r1 = new Rectangle(x, y, KnobX + (KnobSize.Width / 2) - KnobXOffset, BarSize.Height);
                Rectangle r1b = new Rectangle(x, y, KnobX + (KnobSize.Width / 2) - KnobXOffset, BarSize.Height);

                Rectangle r2 = new Rectangle(x + KnobX + (KnobSize.Width / 2) - KnobXOffset + 4, y, x + BarSize.Width - KnobX - 16, BarSize.Height);

                Rectangle r2b = new Rectangle(x + KnobX + (KnobSize.Width / 2) - KnobXOffset + 4, y, x + BarSize.Width - KnobX - 16, BarSize.Height);

                GraphicExtensions.FillRoundedRectangle(g, b_on, r1, BorderRadius);
                GraphicExtensions.DrawRoundedRectangle(g, new Pen(Border_On), r1b, BorderRadius);

                GraphicExtensions.FillRoundedRectangle(g, b_off, r2, BorderRadius);
                GraphicExtensions.DrawRoundedRectangle(g, new Pen(Border_Off), r2b, BorderRadius);
            }

            if (Caption != string.Empty)
            {
                Size s = TextRenderer.MeasureText(Caption, this.Font);

                if (TextIsLeft)
                {
                    g.DrawString(Caption, this.Font, new SolidBrush(this.ForeColor), 0, (this.Height - s.Height) / 2);
                }
                else
                {
                    g.DrawString(Caption, this.Font, new SolidBrush(this.ForeColor), BarSize.Width + 10 + Spacing, (this.Height - s.Height) / 2);
                }
            }

            int KnobY = (this.Height - KnobSize.Height) / 2;

            if (KnobStyle == KnobStyle.Image)
            {
                if (KnobImage != null)
                {
                    g.DrawImage(KnobImage, KnobX, KnobY, KnobSize.Width, KnobSize.Height);
                }

                if (KnobImageOn != null && On)
                {
                    g.DrawImage(KnobImageOn, KnobX, KnobY, KnobSize.Width, KnobSize.Height);
                }
            }
            else if (KnobStyle == KnobStyle.Circle)
            {
                g.FillEllipse(Knob, KnobX, KnobY, KnobSize.Width, KnobSize.Height);
            }
            else if (KnobStyle == KnobStyle.Box)
            {
                g.FillRectangle(Knob, new Rectangle(KnobX, KnobY, KnobSize.Width, KnobSize.Height));
            }
        }

        private void handleCreated(object sender, EventArgs e)
        {
            KnobX = (On) ? BarSize.Width - KnobSize.Width + 3 + KnobXOffset : -1 + KnobXOffset;
            this.Invalidate();
        }

        private void Slider_Click(object sender, EventArgs e)
        {
            if (TextIsLeft)
                KnobXOffset = TextWidth + spacing;
            else
                KnobXOffset = 0;

            if (ToggleSpeed == 0)
            {
                KnobX = (On) ? 0 + KnobXOffset : KnobXOffset + BarSize.Width - (KnobSize.Width / 2);

                On = !On;
                this.Invalidate();
            }
            else
            {
                if (!worker.IsBusy)
                    worker.RunWorkerAsync();
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (On)
            {
                if (TextIsLeft)
                    KnobXOffset = TextWidth + spacing;
                else
                    KnobXOffset = 0;

                for (int i = KnobXOffset + BarSize.Width - KnobSize.Width + 3; i > -1 + KnobXOffset; i--)
                {
                    KnobX = i;
                    System.Threading.Thread.Sleep(ToggleSpeed);
                    worker.ReportProgress(i);
                }
            }
            else
            {
                if (TextIsLeft)
                    KnobXOffset = TextWidth + spacing;
                else
                    KnobXOffset = 0;

                for (int i = -1 + KnobXOffset; i < BarSize.Width - KnobSize.Width + 3 + KnobXOffset; i++)
                {
                    KnobX = i;

                    System.Threading.Thread.Sleep(ToggleSpeed);
                    worker.ReportProgress(i);
                }
            }
            On = !On;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ProgressChangedEventHandler(worker_ProgressChanged), new object[] { sender, e });
                return;
            }

            this.Refresh();
        }
    }
}