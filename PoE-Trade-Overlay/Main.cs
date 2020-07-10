using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DirectWrite;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Factory = SharpDX.Direct2D1.Factory;
using FontFactory = SharpDX.DirectWrite.Factory;
using Format = SharpDX.DXGI.Format;

namespace PoE_Trade_Overlay
{
    public partial class Main : Form
    {
        #region DLLImport

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        [DllImport("dwmapi.dll")]
        public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref int[] pMargins);

        #endregion DLLImport

        #region SDX Stuff

        private WindowRenderTarget device;
        private HwndRenderTargetProperties renderProperties;
        private SolidColorBrush solidColorBrush;
        private Factory factory;

        private TextFormat font, fontSmall;

        private FontFactory fontFactory;
        private const string fontFamily = "Consolas";
        private const float fontSize = 12.0f;
        private const float fontSizeSmall = 10.0f;
        private IntPtr handle;

        public const UInt32 SWP_NOSIZE = 0x0001;
        public const UInt32 SWP_NOMOVE = 0x0002;
        public const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        public static IntPtr HWND_TOPMOST = new IntPtr(-1);

        public Thread sDX = null;

        #endregion SDX Stuff

        public bool render;
        public System.Timers.Timer t_poeChecker;
        public static Main instance;
        public static Form_Search form_Search;
        public ContextMenu rightClickContext;
        public static Panel panel;

        public DiscordRichPresence drp;

        public Main()
        {
            instance = this;
            this.handle = Handle;
            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, 0);
            OnResize(null);

            InitializeComponent();
            panel = panel_Main;
            pb_drag.AssignMoveEvents();
            TransparencyKey = Color.Black;
            SetupSDX();
            SetupContextsAndTimer();
            Config.Load();
            panel_Main.Location = new Point(Config.GetEntry("Main Panel Location X").ToInt(), Config.GetEntry("Main Panel Location Y").ToInt());
            Application.ApplicationExit += Application_ApplicationExit;
            //drp = new DiscordRichPresence();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            t_poeChecker.Stop();
        }

        private void SetupContextsAndTimer()
        {
            tray.ContextMenuStrip = new ContextMenuStrip();
            tray.ContextMenuStrip.Items.Add("Check for Update", null, Context_Update);
            tray.ContextMenuStrip.Items.Add("View Statistics (poeto.net)", null, Context_Update);
            tray.ContextMenuStrip.Items.Add("Settings", null, Context_Settings);
            tray.ContextMenuStrip.Items.Add("-");
            tray.ContextMenuStrip.Items.Add("Exit", null, Context_Exit);

            rightClickContext = new ContextMenu();
            rightClickContext.MenuItems.Add(new MenuItem("Exit", Context_Exit));
            //rightClickContext.MenuItems.Add(new MenuItem("Check for Update", Context_Update));
            rightClickContext.MenuItems.Add(new MenuItem("Settings", Context_Settings));
            rightClickContext.MenuItems.Add(new MenuItem("View Statistics (poeto.net)", Context_Statistics));
            rightClickContext.MenuItems.Add(new MenuItem("-"));
            rightClickContext.MenuItems.Add(new MenuItem("Toggle DnD", Context_DND));
            rightClickContext.MenuItems.Add(new MenuItem("Return to Hideout", Context_HO));
            // Poeto.net
            // dnd
            //
            // Create Timer and check in tick event if poe is active
            t_poeChecker = new System.Timers.Timer();
            t_poeChecker.Elapsed += new ElapsedEventHandler(Checker_Tick);
            t_poeChecker.Interval = 1000;
            t_poeChecker.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs e)// create the whole form
        {
            int[] marg = new int[] { 0, 0, Width, Height };
            DwmExtendFrameIntoClientArea(this.Handle, ref marg);
        }

        #region sDX

        private void SetupSDX()
        {
            this.DoubleBuffered = true;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.Opaque |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            this.TopMost = true;
            this.Visible = true;

            factory = new Factory();
            fontFactory = new FontFactory();
            renderProperties = new HwndRenderTargetProperties()
            {
                Hwnd = this.Handle,
                PixelSize = new Size2(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height),
                PresentOptions = PresentOptions.Immediately
            };

            device = new WindowRenderTarget(factory, new RenderTargetProperties(new PixelFormat(Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied)), renderProperties);
            solidColorBrush = new SolidColorBrush(device, new SharpDX.Mathematics.Interop.RawColor4(255, 255, 255, 255));
            font = new TextFormat(fontFactory, fontFamily, fontSize);
            fontSmall = new TextFormat(fontFactory, fontFamily, fontSizeSmall);
            sDX = new Thread(new ParameterizedThreadStart(SDXThread));
            sDX.Priority = ThreadPriority.Highest;
            sDX.IsBackground = true;

            sDX.Start();
        }

        public void AbortSDX()
        {
            sDX.Abort();
        }

        private void SDXThread(object sender)
        {
            while (render)
            {
                device.BeginDraw();
                device.Clear(new SharpDX.Mathematics.Interop.RawColor4(0, 0, 0, 0));
                device.EndDraw();
                //Thread.Sleep(100);
            }
        }

        #endregion sDX

        private void Checker_Tick(object source, ElapsedEventArgs e)
        {
            if (true) //Config.onlyRenderIfPoeIsActive
            {
                if (ApplicationIsActivated("PathOfExile_x64") | ApplicationIsActivated("PathOfExile_x64Steam"))
                    render = true;
                else if (ApplicationIsActivated("PoE-Trade-Overlay"))
                    render = true;
                else
                    render = true;
            }
            else
            {
                render = true;
            }

            // Check if Form is already disposed
            if (this != null && render != null)
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(delegate { this.Visible = render; }));
                else
                    this.Visible = render;
            }
            /*
            if (Form_Search.instance != null)
            {
                if (Form_Search.instance.InvokeRequired)
                    if (!Form_Search.instance.hide)
                        Form_Search.instance.Invoke(new MethodInvoker(delegate { Form_Search.instance.Visible = render; }));
            }*/
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (Form_Search.instance == null)
            {
                Form_Search fs = new Form_Search();
                fs.Show();
            }
            else
            {
                Form_Search.instance.Show();
            }
        }

        #region Context Menu Events

        private void Context_Exit(object sender, EventArgs e)
        {
            Config.Save();
            Application.Exit();
        }

        private void Context_Statistics(object sender, EventArgs e)
        {
            Process.Start("https://www.poeto.net/");
        }

        private void Context_Update(object sender, EventArgs e)
        {
            /*
            PoE_Trade_Overlay.Update.Check();
            */
        }

        private void Context_Settings(object sender, EventArgs e)
        {
            Form_Settings form_Settings = new Form_Settings();
            form_Settings.ShowDialog(this);
        }

        private void Context_HO(object sender, EventArgs e)
        {
            ChatHelper.SendChatMessage("/hideout");
        }

        private void Context_DND(object sender, EventArgs e)
        {
            ChatHelper.SendChatMessage("/dnd");
        }

        #endregion Context Menu Events

        private void settings_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightClickContext.Show((Control)this, Cursor.Position);
            }
            else if (e.Button == MouseButtons.Left)
            {
                Form_Settings fs = new Form_Settings();
                fs.ShowDialog(this);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                Console.WriteLine("HO");
                // Chathelper.Post("/hideout")
            }
        }

        public static bool ApplicationIsActivated(string app)
        {
            var activatedHandle = GetForegroundWindow();

            if (activatedHandle == IntPtr.Zero)
                return false;

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;

            GetWindowThreadProcessId(activatedHandle, out activeProcId);
            string activeProcName = Process.GetProcessById(activeProcId).ProcessName.ToString();

            if (activeProcName.Equals(app))
                return true;
            else
                return false;
        }
    }
}