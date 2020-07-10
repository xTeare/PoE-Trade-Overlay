using PoE_Trade_Overlay.Controls;
using PoE_Trade_Overlay.Queries;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay
{
    public partial class Form_Settings : Form
    {
        public Form_Settings()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            InitializeComponent();
            LoadFromConfig();
            SetTips();
        }

        private void SetTips()
        {
            CustomTooltip tip = new CustomTooltip();
            tip.InitialDelay = 0;
            tip.AutoPopDelay = 32766;
            tip.UseAnimation = false;
            tip.UseFading = false;

            tip.SetToolTip(help_Discord, "If enabled, the overlay will update your Discord Rich Presence with your current zone.\nThis sadly only works if you start Path of Exile before the overlay");
            tip.SetToolTip(help_PiC, "If enabled, search results will show the listed items price also in chaos.\nThe chaos exchange rates are taken from poe.ninja");
            tip.SetToolTip(help_Sockets, "If enabled, hovering over an item in the search results will hide the sockets.\nLeaving the item with your cursor reshows the sockets");
            tip.SetToolTip(help_Afk, "If enabled, listings where the seller is afk are filtered.\nThis can greatly reduce the result count!");
            tip.SetToolTip(help_Legacy, "If enabled, the search box will only show maps of the current atlas version");
            tip.SetToolTip(help_Render, "If enabled, the Overlay is only visible when Path of Exile is active");
            tip.SetToolTip(help_Statistics, "If enabled, the Overlay will send anonymous data\nabout your search behaviour to poeto.net.\nYou can view all statistics there.");
        }

        private void LoadFromConfig()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name == "Toggle")
                {
                    Toggle t = (Toggle)c;
                    t.On = Config.GetEntryB(t.Caption);
                }
            }

            foreach (LeagueResult r in Data.leagues.Result)
                fcb_leagues.Items.Add(r.Id);

            if (fcb_leagues.Items.Count > 0)
            {
                if (fcb_leagues.Items.Contains(Config.GetEntry("League")))
                {
                    fcb_leagues.SelectedIndex = fcb_leagues.Items.IndexOf(Config.GetEntry("League"));
                }
                else
                {
                    fcb_leagues.SelectedIndex = 0;
                }
            }
        }

        public void Ok(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType().Name == "Toggle")
                {
                    Toggle t = (Toggle)c;
                    Config.SetEntry(t.Caption, t.On.ToString());
                }
            }

            if (fcb_leagues.Items[fcb_leagues.SelectedIndex].ToString() != string.Empty)
            {
                Config.SetEntry("League", fcb_leagues.Items[fcb_leagues.SelectedIndex].ToString());
            }

            Config.Save(true);
            this.Close();
        }
    }
}