using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PoE_Trade_Overlay
{
    public partial class Form_Startup : Form
    {
        public Form_Startup()
        {
            this.Shown += new EventHandler(Form_Shown);
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;
            InitializeComponent();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            Startup();
        }

        private void CreateID()
        {
            string machine = Environment.MachineName;
            string pid = "";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (key != null)
                pid = (string)key.GetValue("ProductID");
            string encode = "poeto-" + pid + "-" + machine;

            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(encode));

            File.WriteAllText("id", encoded);
        }

        private void PrepID()
        {
            if (File.Exists("id"))
            {
                Console.WriteLine("ID Exists, checking content");
                try
                {
                    var base64EncodedBytes = Convert.FromBase64String(File.ReadAllText("id"));
                    string t = Encoding.UTF8.GetString(base64EncodedBytes);
                    if (!t.Contains("poeto-"))
                        CreateID();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Form_Startup::PrepID() Exception : " + e.Message);
                    CreateID();
                }
            }
            else
            {
                CreateID();
            }
        }

        private void Startup()
        {
            Application.DoEvents();

            Append("Loading Config");
            Config.Load();

            Append("Checking for id");
            PrepID();

            Append("Testing connection to 'www.pathofexile.com'");
            if (Extensions.CanConnect("www.pathofexile.com"))
            {
                Append("www.pathofexile.com is online. Continue loading");

                Append("Testing connection to 'poe.ninja'");
                if (Extensions.CanConnect("poe.ninja"))
                {
                    Append("poe.ninja is online. Price in Chaos conversion enabled");
                    string league = Config.GetEntry("League");
                    Append("Downloading currency rates for " + league);
                    Ninja.isEnabled = false;
                    //Ninja.Load(league);
                }
                else
                {
                    Append("poe.ninja is offline? Price in Chaos conversion disabled");
                    Ninja.isEnabled = false;
                }

                Append("Loading Data");
                Data.Load();

                Append("Getting League information");
                Data.LoadLeagues();

                Append("Downloading and parsing Currency (This may take a while)");

                if (Data.LoadCurrency())
                    Append("Loading Currency finished");
                else
                    Append("Failed to load currency !");

                Append("Downloading and parsing Items");
                Data.LoadItems();

                Append("Downloading and parsing Mods");
                Data.LoadStats();

                Append("Loading main program");
                Main main = new Main();
                main.Shown += MainIsShown;
            }
            else
            {
                Append("Could not reach 'www.pathofexile.com'" + Environment.NewLine);
                DialogResult dr = MessageBox.Show("Could not reach pathofexile.com\nPlease check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (dr == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
        }

        public void MainIsShown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Append(string text)
        {
            Label lbl = new Label()
            {
                ForeColor = Color.FromArgb(175, 237, 237),
                Font = new Font(Font.FontFamily, 10),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = text,
                Height = 18,
                Width = flp.Width - 24
            };
            flp.Controls.Add(lbl);
            flp.ScrollControlIntoView(lbl);
            flp.Refresh();
            flp.Invalidate();
        }
    }
}