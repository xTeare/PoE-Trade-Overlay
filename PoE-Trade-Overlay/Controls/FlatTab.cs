using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

/// <summary>
/// Thanks to LarsTech @ https://stackoverflow.com/questions/7768555/tabcontrol-and-borders-visual-glitch/7785745#7785745
/// </summary>
namespace PoE_Trade_Overlay.Controls
{
    public class FlatTab : NativeWindow
    {
        private const int WM_PAINT = 0xF;

        private TabControl tabControl;

        public FlatTab(TabControl tc)
        {
            tabControl = tc;
            tabControl.Selected += new TabControlEventHandler(tabControl_Selected);
            AssignHandle(tc.Handle);
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            tabControl.Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                using (Graphics g = Graphics.FromHwnd(m.HWnd))
                {
                    //Replace the outside white borders:
                    if (tabControl.Parent != null)
                    {
                        g.SetClip(new Rectangle(0, 0, tabControl.Width - 3, tabControl.Height - 2), CombineMode.Exclude);
                        //
                        using (SolidBrush sb = new SolidBrush(tabControl.SelectedTab.BackColor))
                            g.FillRectangle(sb, new Rectangle(0,
                                                              tabControl.ItemSize.Height + 2,
                                                              tabControl.Width,
                                                              tabControl.Height - (tabControl.ItemSize.Height + 2)));
                    }

                    //Replace the inside white borders:
                    if (tabControl.SelectedTab != null)
                    {
                        g.ResetClip();
                        Rectangle r = tabControl.SelectedTab.Bounds;
                        g.SetClip(r, CombineMode.Exclude);
                        //
                        using (SolidBrush sb = new SolidBrush(tabControl.SelectedTab.BackColor))
                            g.FillRectangle(sb, new Rectangle(r.Left - 5,
                                                              r.Top - 1,
                                                              r.Width + 6,
                                                              r.Height + 4));
                    }

                    // Draw Separator
                    SolidBrush solidBrush = new SolidBrush(Color.FromArgb(20, 22, 24));

                    g.FillRectangle(solidBrush, new Rectangle(0, tabControl.ItemSize.Height + 1, tabControl.Width, 4));

                    // This does need some rework as it just renders the first times - > No Scroll support
                    /*
                    // Draw header background
                    g.FillRectangle(new SolidBrush(tabControl.SelectedTab.BackColor), new Rectangle(0, 0, tabControl.Width, tabControl.ItemSize.Height));

                    int index = 0;
                    foreach(TabPage tp in tabControl.TabPages)
                    {
                        TabPage page = tp;

                        if(tabControl.TabPages[tabControl.SelectedIndex] == tp)
                        {
                            g.FillRectangle(new SolidBrush(Color.YellowGreen), new Rectangle(tabControl.ItemSize.Width * index, 0, tabControl.ItemSize.Width, tabControl.ItemSize.Height));
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(tabControl.ItemSize.Width * index, 0, tabControl.ItemSize.Width, tabControl.ItemSize.Height));
                        }

                        Rectangle paddedBounds = tabControl.Bounds;
                        paddedBounds.Offset(1, 1);
                        TextRenderer.DrawText(g, page.Text, tabControl.Font, new Rectangle(tabControl.ItemSize.Width * index, 0, tabControl.ItemSize.Width, tabControl.ItemSize.Height), page.ForeColor);
                        index++;
                    }

                    */
                }
            }
        }
    }
}