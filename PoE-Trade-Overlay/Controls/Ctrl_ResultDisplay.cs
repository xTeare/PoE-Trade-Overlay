using Newtonsoft.Json;
using PoE_Trade_Overlay.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Ctrl_ResultDisplay : UserControl
    {
        public Queries.Result result;

        private const int offset_itemName = 8;
        private const int width_itemName = 34;
        private const int height_lbl = 18;
        private const int height_itemName = 44;
        private const int height_separator = 8;
        private Color color;
        private string itemName;
        private string scamVotes;

        public Ctrl_ResultDisplay()
        {
            InitializeComponent();
            pb_itemArt.MouseEnter += new EventHandler(HideSockets);
            pb_itemArt.MouseLeave += new EventHandler(ShowSockets);
        }

        #region pb_ItemArt Events

        // Loads Item art async and sets location, size and sockets afterwards
        private void TryLoadItemArt(string url)
        {
            try
            {
                pb_itemArt.LoadCompleted += Pb_itemArt_LoadCompleted;
                pb_itemArt.LoadAsync(url);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ctrl_ResultDisplay::TryLoadItemArt Exception : " + e.Message);
            }
        }

        private void Pb_itemArt_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Image icon = pb_itemArt.Image;

            int w = icon.Width;
            int h = icon.Height;

            int x = (106 / 2) - (w / 2);
            int y = (flp_item.Height / 2) - (h / 2);
            pb_itemArt.Location = new Point(x, y);
            pb_itemArt.Size = new Size(w, h);
            SetSockets();
        }

        #endregion pb_ItemArt Events

        public void QueryData()
        {
            bool isGem = false;
            switch (result.Item.FrameType)
            {
                case 0: /// NORMAL ITEM
                    itemName = result.Item.Name + result.Item.TypeLine;
                    color = Constants.Normal;
                    break;

                case 1: /// MAGIC ITEM
                    itemName = result.Item.Name + result.Item.TypeLine;
                    color = Constants.Magic;
                    break;

                case 2: /// RARE ITEM
                    itemName = result.Item.Name + " " + result.Item.TypeLine;
                    color = Constants.Rare;
                    break;

                case 3: /// UNIQUE ITEM
                    itemName = result.Item.Name + " " + result.Item.TypeLine;
                    color = Constants.Unique;
                    btn_wiki.Visible = true;

                    break;

                case 4: /// SKILL GEM
                    itemName = result.Item.TypeLine;
                    color = Constants.Gem;
                    btn_wiki.Visible = true;
                    isGem = true;
                    break;

                case 5: /// ESSENCE
                    itemName = result.Item.TypeLine;
                    color = Constants.Currency;
                    btn_wiki.Visible = true;
                    break;

                #region DIV

                case 6: /// DIVINATION CARD
                /*

                pb_header_left.Visible = false;
                pb_header_center.Visible = false;
                pb_header_right.Visible = false;
                flp_item.Visible = false;

                BetterPictureBox bpb_frame = new BetterPictureBox();
                bpb_frame.Image = Properties.Resources.DivinationCard;
                bpb_frame.Size = new Size((int)(bpb_frame.Image.Width * 0.75), (int)(bpb_frame.Image.Height * 0.75));
                bpb_frame.SizeMode = PictureBoxSizeMode.StretchImage;
                bpb_frame.Location = new Point((this.Width / 2) - (bpb_frame.Size.Width / 2), 0);

                BetterPictureBox bpb_art = new BetterPictureBox();

                bpb_art.LoadAsync("https://www.pathofexile.com/image/gen/divination_cards/" + result.Item.ArtFilename + ".png");

                bpb_art.Size = new Size((int)(237 * 0.75), (int)(170 * 0.75));
                bpb_art.Location = new Point(bpb_frame.Location.X + 15, bpb_frame.Location.Y + 30);
                bpb_art.SizeMode = PictureBoxSizeMode.StretchImage;

                Label lbl_name = new Label();
                lbl_name.Location = new Point(0, 1);
                lbl_name.Size = new Size(bpb_frame.Width, 32);
                lbl_name.Font = new Font(lbl_name.Font.FontFamily, 9, FontStyle.Regular);
                lbl_name.ForeColor = Color.Black;
                lbl_name.BackColor = Color.Transparent;
                lbl_name.Text = result.Item.TypeLine;
                lbl_name.TextAlign = ContentAlignment.MiddleCenter;
                bpb_frame.Controls.Add(lbl_name);

                Label lbl_stack = new Label();
                bpb_frame.Controls.Add(lbl_stack);
                lbl_stack.Location = new Point(15, 140);
                lbl_stack.Size = new Size(43, 22);
                lbl_stack.TextAlign = ContentAlignment.MiddleCenter;
                lbl_stack.ForeColor = Color.White;
                lbl_stack.BackColor = Color.Transparent;
                lbl_stack.Text = string.Format("{0}/{1}", result.Item.StackSize, result.Item.MaxStackSize);

                Label lbl_flav = new Label();
                bpb_frame.Controls.Add(lbl_flav);
                lbl_flav.Location = new Point(7, 225);
                lbl_flav.Size = new Size(bpb_frame.Width - 14, 300);
                lbl_flav.TextAlign = ContentAlignment.TopCenter;
                lbl_flav.Font = new Font(lbl_flav.Font.FontFamily, 8, FontStyle.Italic);

                lbl_flav.ForeColor = Color.FromArgb(175, 96, 37);
                lbl_flav.BackColor = Color.Transparent;

                string flav = "";
                foreach (string s in result.Item.FlavourText)
                {
                    string str = s;
                    str = str.RemoveFromTo("<", ">");
                    str = str.Replace("{", "");
                    str = str.Replace("}", "");
                    flav += str.Replace("\r", "") + "\n";
                }

                lbl_flav.Text = flav;

                if (result.Item.ExplicitMods != null)
                {
                    Label lbl_item = new Label();
                    bpb_frame.Controls.Add(lbl_item);
                    lbl_item.Location = new Point(10, 157);
                    lbl_item.Size = new Size(bpb_frame.Width - 20, 44);
                    lbl_item.TextAlign = ContentAlignment.MiddleCenter;
                    lbl_item.Font = new Font(lbl_item.Font.FontFamily, 8, FontStyle.Bold);
                    lbl_item.ForeColor = Color.White;
                    lbl_item.BackColor = Color.Transparent;

                    string t = result.Item.ExplicitMods[0];

                    if (t.Contains("<whiteitem>"))
                    {
                        lbl_item.ForeColor = Constants.Normal;
                        t = t.Replace("<whiteitem>", "");
                    }
                    else if (t.Contains("<magicitem>"))
                    {
                        lbl_item.ForeColor = Constants.Magic;
                        t = t.Replace("<magicitem>", "");
                    }
                    else if (t.Contains("<rareitem>"))
                    {
                        lbl_item.ForeColor = Constants.Rare;
                        t = t.Replace("<rareitem>", "");
                    }
                    else if (t.Contains("<uniqueitem>"))
                    {
                        lbl_item.ForeColor = Constants.Unique;
                        t = t.Replace("<uniqueitem>", "");
                    }
                    else if (t.Contains("<gemitem>"))
                    {
                        lbl_item.ForeColor = Constants.Gem;
                        t = t.Replace("<gemitem>", "");
                    }
                    else if (t.Contains("<prophecy>"))
                    {
                        lbl_item.ForeColor = Constants.Prophecy;
                        t = t.Replace("<prophecy>", "");
                    }
                    else if (t.Contains("<divination>"))
                    {
                        lbl_item.ForeColor = Constants.Divination;
                        t = t.Replace("<divination>", "");
                    }
                    else if (t.Contains("<currencyitem>"))
                    {
                        lbl_item.ForeColor = Constants.Currency;
                        t = t.Replace("<currencyitem>", "");
                    }

                    t = t.Replace("{", "");
                    t = t.Replace("}", "");
                    t = t.Replace("\r", "");
                    t = t.Replace("<corrupted>", "");
                    t = t.Replace("<default>", "");
                    t = t.Replace("<normal>", "");
                    t = t.RemoveFromTo("<", ">");

                    lbl_item.Text = t;
                }

                div = bpb_frame;
                this.Controls.Add(bpb_frame);
                this.Controls.Add(bpb_art);

                btn_wiki.Visible = true;
                break;
                */

                #endregion DIV

                case 8: /// PROPHECY
                    itemName = result.Item.TypeLine;
                    color = Constants.Prophecy;
                    btn_wiki.Visible = true;
                    break;

                case 9: /// FOIL
                    itemName = result.Item.Name + " " + result.Item.TypeLine;
                    color = Constants.Relic;
                    btn_wiki.Visible = true;
                    break;
            }

            AppendLabel(itemName, 12, color);
            AppendSeperator(Constants.Normal);

            if (result.Item.Properties != null)
            {
                foreach (Queries.Property prop in result.Item.Properties)
                {
                    bool magicColor = false;
                    string text = "";
                    List<LabelColor> lblColors = new List<LabelColor>();

                    if (result.Item.TypeLine.Contains("Flask"))
                    {
                        text = prop.Name;

                        for (int i = 0; i < prop.Values.Count; i++)
                            for (int j = 0; j < prop.Values[i].Count; j++)
                                text = text.Replace("%" + i, prop.Values[i][j].String);
                    }
                    else
                    {
                        text = prop.Name;

                        lblColors.Add(new LabelColor(text, Constants.Normal, 10f));

                        if (prop.Values.Count > 0)
                        {
                            foreach (List<Queries.Value> val in prop.Values)
                            {
                                Color c = Constants.Normal;
                                LabelColor lbl = new LabelColor("", Constants.Normal, 10f);

                                foreach(Queries.Value val2 in val)
                                {
                                    if (val2.String != null)
                                        lbl.Text = val2.String;

                                    if(val2.Integer != null)
                                    {
                                        switch (val2.Integer)
                                        {
                                            case 1: 
                                                c = Constants.Magic;
                                                break;

                                            case 4: 
                                                c = Constants.Fire;
                                                break;

                                            case 5: 
                                                c = Constants.Cold;
                                                break;

                                            case 6:
                                                c = Constants.Lightning;
                                                break;

                                            case 7:
                                                c = Constants.Chaos;
                                                break;

                                        }
                                        lbl.Color = c;
                                    }
                                        
                                }
                                lblColors.Add(lbl);
                            }
                        }
                    }
                    AppendColoredLabel(lblColors);

                }
                AppendSeperator(Constants.Normal);
            }

            if (result.Item.ImplicitMods != null)
            {
                foreach (string imp in result.Item.ImplicitMods)
                {
                    AppendLabel(imp, 10);

                    /// Find Magnitudes for explicit mods
                    /// Set Control_Magnitudes Labels
                    if (result.Item.Extended != null && result.Item.Extended.Mods != null && result.Item.Extended.Mods.Explicit != null)
                    {
                        //string modId = Data.GetModIdByText(Regex.Replace(imp, @"\d", "#").Replace("##", "#").Replace("+", "").Replace("-", ""));
                        foreach (Queries.ExplicitClass ex in result.Item.Extended.Mods.Explicit)
                        {
                            if (ex.Magnitudes != null)
                            {
                            }
                        }
                    }
                }
                AppendSeperator(Constants.Normal);
            }


            if (result.Item.ExplicitMods != null)
            {
                foreach (string exp in result.Item.ExplicitMods)
                {
                    if (!isGem)
                        AppendLabel(exp, 10, true);
                    else
                        AppendLabel(exp, 10, Constants.Magic, false);

                    /// Find Magnitudes for explicit mods
                    ///
                    if (result.Item.Extended != null && result.Item.Extended.Mods != null && result.Item.Extended.Mods.Explicit != null)
                    {
                        //string modId = Data.GetModIdByText(Regex.Replace(exp, @"\d", "#").Replace("##", "#").Replace("+", "").Replace("-", ""));

                        foreach (Queries.ExplicitClass ex in result.Item.Extended.Mods.Explicit)
                        {
                        }
                    }
                }
                AppendSeperator(Constants.Normal);
            }

            if(result.Item.CraftMods != null)
            {
                foreach(string craft in result.Item.CraftMods)
                {
                    AppendLabel(craft, 10, Constants.Craft, true, "craft");
                }
            }

            if(result.Item.VeiledMods != null)
            {
                foreach(string veil in result.Item.VeiledMods)
                {
                    AppendVeiled(veil.BetterContains("Prefix", StringComparison.OrdinalIgnoreCase));
                }
            }

            if (result.Item.Duplicated)
                AppendLabel("Mirrored", 10, Constants.Corrupted);

            if (result.Item.Corrupted)
                AppendLabel("Corrupted", 10, Constants.Corrupted);

            if(result.Item.PseudoMods != null)
            {
                foreach(string pseudo in result.Item.PseudoMods)
                {
                    AppendLabel(pseudo, 10, Constants.Placeholder, true, "pseudo");
                }
                AppendSeperator(Constants.Normal);
            }


            Ctrl_AccInfo accInfo = new Ctrl_AccInfo();
            accInfo.QueryData(result);
            flp_item.Controls.Add(accInfo);
            TryLoadItemArt(result.Item.Icon.ToString());
        }

        public void SetSockets()
        {
            if (result.Item.Sockets == null)
                return;

            // Set offset for larger images like bows
            int offset = 0;

            if (pb_itemArt.Image.Height > 141)
            {
                int num1 = pb_itemArt.Image.Height - 141;
                offset = num1 / 2;
            }

            // Check if there are any Links and if there are create Lonk images
            // We need to do that first in order to have the Lonk images above the sockets.
            if (result.Item.Sockets.Count >= 2)
            {
                if (result.Item.Sockets[0].Group == result.Item.Sockets[1].Group)
                {
                    BetterPictureBox bpb_linked = new BetterPictureBox();
                    pb_itemArt.Controls.Add(bpb_linked);
                    bpb_linked.Size = new Size(38, 16);
                    bpb_linked.BackColor = Color.Transparent;
                    bpb_linked.Location = new Point(28, 16 + offset);
                    bpb_linked.Image = Properties.Resources.link_horizontal;
                }
            }

            if (result.Item.Sockets.Count >= 3)
            {
                if (result.Item.Sockets[1].Group == result.Item.Sockets[2].Group)
                {
                    BetterPictureBox bpb_linked = new BetterPictureBox();
                    pb_itemArt.Controls.Add(bpb_linked);
                    bpb_linked.Size = new Size(16, 38);
                    bpb_linked.BackColor = Color.Transparent;
                    bpb_linked.Location = new Point(63, 28 + offset);
                    bpb_linked.Image = Properties.Resources.link_Vertical;
                }
            }

            if (result.Item.Sockets.Count >= 4)
            {
                if (result.Item.Sockets[2].Group == result.Item.Sockets[3].Group)
                {
                    BetterPictureBox bpb_linked = new BetterPictureBox();
                    pb_itemArt.Controls.Add(bpb_linked);
                    bpb_linked.Size = new Size(38, 16);
                    bpb_linked.BackColor = Color.Transparent;
                    bpb_linked.Location = new Point(28, 63 + offset);
                    bpb_linked.Image = Properties.Resources.link_horizontal;
                }
            }

            if (result.Item.Sockets.Count >= 5)
            {
                if (result.Item.Sockets[3].Group == result.Item.Sockets[4].Group)
                {
                    BetterPictureBox bpb_linked = new BetterPictureBox();
                    pb_itemArt.Controls.Add(bpb_linked);
                    bpb_linked.Size = new Size(16, 38);
                    bpb_linked.BackColor = Color.Transparent;
                    bpb_linked.Location = new Point(16, 75 + offset);
                    bpb_linked.Image = Properties.Resources.link_Vertical;
                }
            }

            if (result.Item.Sockets.Count >= 6)
            {
                if (result.Item.Sockets[4].Group == result.Item.Sockets[5].Group)
                {
                    BetterPictureBox bpb_linked = new BetterPictureBox();
                    pb_itemArt.Controls.Add(bpb_linked);
                    bpb_linked.Size = new Size(38, 16);
                    bpb_linked.BackColor = Color.Transparent;
                    bpb_linked.Location = new Point(28, 110 + offset);
                    bpb_linked.Image = Properties.Resources.link_horizontal;
                }
            }
            for (int i = 0; i < result.Item.Sockets.Count; i++)
            {
                BetterPictureBox bpb = new BetterPictureBox();
                pb_itemArt.Controls.Add(bpb);
                bpb.BackColor = Color.Transparent;
                bpb.Size = new Size(47, 47);

                bpb.Location = new Point(Data.socketPositions.Rows[i]["x"].ToString().ToInt(), Data.socketPositions.Rows[i]["y"].ToString().ToInt() + offset);

                switch (result.Item.Sockets[i].SColour)
                {
                    case "R":
                        bpb.Image = Properties.Resources.str;
                        break;

                    case "G":
                        bpb.Image = Properties.Resources.dex;
                        break;

                    case "B":
                        bpb.Image = Properties.Resources._int;
                        break;

                    case "W":
                        bpb.Image = Properties.Resources.gen;
                        break;
                }
            }

            PictureBox bpb_event = new PictureBox();
            pb_itemArt.Controls.Add(bpb_event);
            bpb_event.Size = new Size(pb_itemArt.Width, pb_itemArt.Height);
            bpb_event.BackColor = Color.Transparent;
            bpb_event.Location = new Point(0, 0);
            bpb_event.MouseEnter += HideSockets;
            bpb_event.MouseLeave += ShowSockets;
        }

        private void HideSockets(object sender, EventArgs e)
        {
            if (Config.GetEntryB("Hide Sockets on Hover"))
                foreach (Control c in pb_itemArt.Controls)
                    c.Visible = false;
        }

        private void ShowSockets(object sender, EventArgs e)
        {
            if (Config.GetEntryB("Hide Sockets on Hover"))
                foreach (Control c in pb_itemArt.Controls)
                    c.Visible = true;
        }

        #region AppendShit

        private void AppendVeiled(bool isPrefix)
        {
            flp_item.Controls.Add(new PictureBox()
            {
                Image = (isPrefix) ? Properties.Resources.VeiledPrefix : Properties.Resources.VeiledSuffix,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Width = 474,
                Height = 20
            }) ;
        }

        public void AppendColoredLabel(List<LabelColor> labels)
        {
            ColoredLabel lbl = new ColoredLabel
            {
                Width = flp_item.Width - 4,
                Labels = labels,
                Height = 15,
                Font = labels[0].GetFont
            };

            flp_item.Controls.Add(lbl);
        }

        private void AppendLabel(string text, float fontSize, bool hasEvents = false)
        {
            Size s = TextRenderer.MeasureText(text, new Font("Consolas", fontSize), new Size(500, 0), TextFormatFlags.WordBreak);
            Console.WriteLine(s.Height);
            Label lbl = new Label()
            {
                Font = new Font("Consolas", fontSize),
                ForeColor = Color.FromArgb(200, 200, 200),
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                Height = s.Height,
                Width = flp_item.Width - 4
            };

            if (hasEvents)
            {
                lbl.MouseEnter += ModLabel_Enter;
                lbl.MouseLeave += ModLabel_Leave;
                lbl.MouseClick += ModLabel_MouseClick;
            }

            flp_item.Controls.Add(lbl);
        }

        private void AppendLabel(string text, float fontSize, Color foreColor, bool hasEvents = false, string modType = "")
        {
            Size s = TextRenderer.MeasureText(text, new Font("Consolas", fontSize), new Size(500, 0), TextFormatFlags.WordBreak);
            Label lbl = new Label()
            {
                Font = new Font("Consolas", fontSize),
                ForeColor = foreColor,
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                Height = s.Height,
                Name = modType,
                Width = flp_item.Width - 4
            };

            if (hasEvents)
            {
                lbl.MouseEnter += ModLabel_Enter;
                lbl.MouseLeave += ModLabel_Leave;
                lbl.MouseClick += ModLabel_MouseClick;
            }

            flp_item.Controls.Add(lbl);
        }

        private void AppendSeperator(Color color, int height = 1)
        {
            PictureBox pb = new PictureBox()
            {
                BackColor = color,
                Size = new Size(flp_item.Width - 4, height)
            };
            flp_item.Controls.Add(pb);
        }

        #endregion AppendShit

        private void ModLabel_MouseClick(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            string modText = lbl.Text;
            string mod;
            string modID;

            // prepare lbl text

            string removedNumbers = Regex.Replace(modText, @"\d", "#"); // Replace all numbers with #
            removedNumbers = Regex.Replace(removedNumbers, @"#+", "#"); // Replace all # with just one #

            /// Replace reduced with increased on some mods
            if (modText.Contains("reduced"))
                if (!Data.modsWithReduced.Contains(removedNumbers))
                    removedNumbers = removedNumbers.Replace("reduced", "increased");

            // Search Data for mod id
            if (lbl.Text.Contains("(pseudo)"))
            {
                mod = removedNumbers.Replace("(pseudo) ", "");
                modID = Data.GetModID(removedNumbers.Replace("(pseudo) ", ""));
            }
            else
            {
                mod = removedNumbers.Replace("+", "");
                modID = Data.GetModID(removedNumbers.Replace("+", ""));
            }

            // redo search with mod to sort (mod id)
            // Get Tab page
            TabWithQuery tab = (TabWithQuery)this.Parent.Parent;

            Console.WriteLine("MOD : " + mod);
            Console.WriteLine("ModID : " + modID);
            Console.WriteLine("OLD QUERY : " + tab.srm.query);

            Search s = Search.FromJson(tab.srm.query);

            s.Sort = new Sort();
            //s.Sort.stat = (sortModAsc == true) ? "desc" : "asc";
            s.Sort.stat = "desc";
            s.Sort.Price = null;

            var jsonResolver = new PropertyRenameAndIgnoreSerializerContractResolver();
            jsonResolver.RenameProperty(typeof(Sort), "stat", "stat." + modID);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = jsonResolver;

            var json = JsonConvert.SerializeObject(s, serializerSettings);
            tab.srm.query = json;

            Console.WriteLine("NEW QUERY : " + tab.srm.query);

            Form_Search.instance.Query(json, tab, "", "", false, "", true);
        }

        #region Label HoverEvents

        private void ModLabel_Enter(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Constants.HoverEnter;
        }

        private void ModLabel_Leave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.BackColor = Constants.HoverLeave;
        }

        #endregion Label HoverEvents

        private void Ctrl_ResultDisplay_Load(object sender, EventArgs e)
        {
        }

        public void TrashIt()
        {
            List<Control> controls = new List<Control>();

            foreach (Control c in this.Controls)
            {
                controls.Add(c);

                if (c.Controls.Count != 0)
                    foreach (Control c1 in c.Controls)
                        controls.Add(c1);
            }

            foreach (Control c in controls)
            {
                Console.WriteLine(c.GetType().ToString());

                if (c != null)
                    c.Dispose();
            }
        }
    }
}