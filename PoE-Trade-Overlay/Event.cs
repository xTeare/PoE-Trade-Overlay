using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay
{
    public static class Event
    {
        private static bool clicked = false;
        private static int iOldX;
        private static int iOldY;
        private static int iClickX;
        private static int iClickY;
        public static Control panel;

        public static void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                iOldX = p.X;
                iOldY = p.Y;
                iClickX = e.X;
                iClickY = e.Y;
                clicked = true;
            }
        }

        public static void PanelMove_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
            Console.WriteLine(panel.Name);
            switch (panel.Name)
            {
                case "panel_Main":
                    Console.WriteLine(panel.Location.Y);
                    Console.WriteLine(panel.Top);
                    Config.SetEntry("Main Panel Location X", panel.Location.X.ToString());
                    Config.SetEntry("Main Panel Location Y", panel.Location.Y.ToString());

                    break;
            }
            Config.Save();
        }

        public static void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            switch (ctrl.Name)
            {
                case "pb_drag":
                    panel = Main.panel;
                    break;

                case "lbl_Search":
                    panel = Form_Search.instance;
                    break;
            }

            if (clicked)
            {
                Point p = new Point(); // New Coordinate
                p.X = e.X + panel.Left;
                p.Y = e.Y + panel.Top;
                panel.Left = p.X - iClickX;
                panel.Top = p.Y - iClickY;
            }
        }

        public static void AssignMoveEvents(this Control ctrl)
        {
            ctrl.MouseMove += PanelMove_MouseMove;
            ctrl.MouseDown += PanelMove_MouseDown;
            ctrl.MouseUp += PanelMove_MouseUp;
        }
    }
}