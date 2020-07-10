using PoE_Trade_Overlay.Controls;
using PoE_Trade_Overlay.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay
{
    public partial class Form_Search : Form
    {
        public DataTable DT_Items = new DataTable();
        public static Form_Search instance;
        public List<Filter_Mods> modGroups = new List<Filter_Mods>();

        public Form_Search()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            instance = this;
            var tab = new FlatTab(tabControl);
            lbl_Search.AssignMoveEvents();
            PopulateControls();
            AddModGroup("and");
            CalculateModCollapse();

            // Add Influence Images
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateSearchQuery();
        }

        #region Modgroups

        public void AddModGroup(string groupType)
        {
            Filter_Mods mods = new Filter_Mods();
            mods.type = groupType;
            mods.AddSearch();
            ec_Mods.DropZone.Controls.Add(mods);
        }

        public void RemoveModGroup(Filter_Mods m)
        {
            ec_Mods.DropZone.Controls.Remove(m);
            CalculateModCollapse();
        }

        public void CalculateModCollapse()
        {
            int height = 42;
            int num = 0;
            ec_Mods.DropZone.Location = new Point(2, 44);
            foreach (Filter_Mods m in ec_Mods.DropZone.Controls)
            {
                if (num == 0)
                    m.Location = new Point(3, 4);
                else
                    m.Location = new Point(3, ec_Mods.DropZone.Controls[num - 1].Bottom + 4);

                height += m.Height;
                num++;
            }
            height += num * 4;
            ec_Mods.Size = new Size(599, height + 2);
            btn_AddModgroup.Location = new Point(0, 21);
        }

        #endregion Modgroups

        public void Query(string query, TabWithQuery tab = null, string pseudos = "", string modToSort = "", bool sortDesc = false, string header = "", bool clearTab = false)
        {
            // Api Search URL to send the query to
            string url = Constants.SearchURL + Config.GetEntry("League");
            Console.WriteLine(url);

            SearchResultManager srm = null;

            Queries.Listing listings = null;

            if (tab == null)
            {
                // Send Query to API and get the results back as a json (string).
                string sResults = (string)QueryHelper.PostWebRequest(url, query);

                if (sResults == null || sResults == string.Empty)
                    return;

                // JSON to Search Results
                SearchResults sr = SearchResults.FromJson(sResults);

                // Return when there are no results
                if (sr.Result.Count == 0)
                    return;

                // Create a new SearchResult Manager -> We get the Fetch URL for the real listings here
                srm = new SearchResultManager(sr);
                srm.query = query;
                srm.isLoading = true;
                string fetchURL = srm.GetFetchURL(pseudos);
                if (fetchURL == string.Empty)
                    return;

                string sListings = (string)QueryHelper.GetWebRequest(fetchURL);
                if (sListings == string.Empty)
                    return;

                System.IO.File.WriteAllText("query.txt", sListings);

                listings = Queries.Listing.FromJson(sListings);

                tab = CreateTab((header == "") ? "Results" : header, srm);
            }
            else
            {
                if (clearTab)
                {
                    foreach (Control c in tab.Controls)
                    {
                        if (c.GetType() == typeof(FlowLayoutPanel))
                        {
                            Console.WriteLine("IS Layout PANEL");
                            c.Controls.Clear();
                        }
                    }
                }

                tab.srm.isLoading = true;
                string fetchURL = tab.srm.GetFetchURL(pseudos);
                Console.WriteLine(fetchURL);
                if (fetchURL == string.Empty)
                    return;
                string sListings = (string)QueryHelper.GetWebRequest(fetchURL);
                Console.WriteLine(sListings);
                if (sListings == string.Empty)
                    return;

                listings = Queries.Listing.FromJson(sListings);
            }

            if (listings == null || listings.Result == null || listings.Result.Count == 0)
                return;

            FlowLayoutPanel flp = tab.GetFLP();
            foreach (Queries.Result r in listings.Result)
            {
                if (r == null)
                    continue;

                Ctrl_ResultDisplay rd = new Ctrl_ResultDisplay();
                rd.result = r;
                flp.Controls.Add(rd);
                rd.QueryData();
            }
            tabControl.SelectedTab = tab;
            tab.srm.isLoading = false;
        }

        private TabWithQuery CreateTab(string header, SearchResultManager srm)
        {
            string h = header;
            if (h.Length > 16)
            {
                h = h.Remove(16, h.Length - 16);
                h += "...";
            }

            TabWithQuery tab = new TabWithQuery()
            {
                Text = h,
                srm = srm,
                BackColor = Constants.TabBack
            };
            tabControl.TabPages.Add(tab);

            FlowLayoutPanel flp = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                AutoSizeMode = AutoSizeMode.GrowOnly,
                AutoScroll = true,
                WrapContents = false,
                AutoSize = true
            };
            flp.MouseWheel += Flp_MouseWheel;
            flp.Scroll += Flp_Scroll;
            tab.Controls.Add(flp);

            return tab;
        }

        private void CheckFLP(FlowLayoutPanel flp)
        {
            int val = flp.VerticalScroll.Value;
            int max = flp.VerticalScroll.Maximum;
            int height = flp.Height;
            TabPage page = null;
            // Check if the user has scrolled all the way down
            if ((max - val) < height)
            {
                foreach (TabPage p in tabControl.TabPages)
                {
                    if (p.Controls.Contains(flp))
                        page = p;
                }

                if (page != null)
                {
                    TabWithQuery tab = (TabWithQuery)page;

                    if (!tab.srm.isLoading)
                        Query(tab.query, tab, tab.pseudos, tab.modToSort, tab.sortDesc, tab.header);
                }
            }
        }

        private void Flp_Scroll(object sender, ScrollEventArgs e)
        {
            CheckFLP((FlowLayoutPanel)sender);
        }

        private void Flp_MouseWheel(object sender, MouseEventArgs e)
        {
            CheckFLP((FlowLayoutPanel)sender);
        }

        public void GenerateSearchQuery()
        {
            string head = "";
            Search searchQuery = new Search();
            Query query = new Query();
            Sort sort = new Sort();
            QueryFilters queryFilters = new QueryFilters();

            if (tb_ItemSearch.Text != string.Empty)
            {
                if (tb_ItemSearch.Text.IsUniqueMap())
                {
                    TypeClass name = new TypeClass();
                    TypeClass type = new TypeClass();
                    name.Discriminator = Data.GetEntryFromRow(Data.items, 1, "combined", tb_ItemSearch.Text.Replace("'", "%27")).ToDiscriminator();
                    type.Discriminator = Data.GetEntryFromRow(Data.items, 1, "combined", tb_ItemSearch.Text.Replace("'", "%27")).ToDiscriminator();
                    name.Option = Data.GetEntryFromRow(Data.items, 0, "combined", tb_ItemSearch.Text.Replace("'", "%27")).Replace("%27", "'");
                    type.Option = Data.GetEntryFromRow(Data.items, 1, "combined", tb_ItemSearch.Text.Replace("'", "%27")).RemoveFromTo("(", ")", -1);
                    query.Name = name;
                    query.Type = type;
                    //header += string.Format("{0} {1}", name.Option, type.Option);
                }
                else if (tb_ItemSearch.Text.Contains("Map"))
                {
                    TypeClass tc = new TypeClass();
                    tc.Discriminator = Data.GetEntryFromRow(Data.items, 1, "combined", tb_ItemSearch.Text).ToDiscriminator();
                    tc.Option = Data.GetEntryFromRow(Data.items, 0, "combined", tb_ItemSearch.Text);
                    query.Type = tc;
                }
                else
                {
                    string name = Data.GetEntryFromRow(Data.items, 0, "combined", tb_ItemSearch.Text.RemoveFromTo("(", ")").Replace("'", "%27"));
                    string type = Data.GetEntryFromRow(Data.items, 1, "combined", tb_ItemSearch.Text.RemoveFromTo("(", ")").Replace("'", "%27"));

                    // if name == type then its just a base (Coral Ring)
                    if (name == type)
                    {
                        query.Type = type;
                        head += type + "-";
                        Statistics.PostStat(type, "itembase");
                    }
                    else
                    {
                        query.Name = name.Replace("%27", "'");
                        head += name + "-";
                        query.Type = type.Replace("%27", "'");
                        Statistics.PostStat(name, "item");
                    }
                }
            }

            if (!fdd_ItemCategory.IsEmpty())
            {
                Console.WriteLine(Data.GetEntryFromRow(Data.itemTypes, 0, "text", fdd_ItemCategory.GetText()));
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.TypeFilters == null)
                    queryFilters.TypeFilters = new TypeFilters();

                if (queryFilters.TypeFilters.Filters == null)
                    queryFilters.TypeFilters.Filters = new TypeFiltersFilters();

                queryFilters.TypeFilters.Filters.Category = new Status();
                queryFilters.TypeFilters.Filters.Category.Option = Data.GetEntryFromRow(Data.itemTypes, 0, "text", fdd_ItemCategory.GetText());
            }

            if (!fdd_ItemRarity.IsEmpty())
            {
                Console.WriteLine(Data.GetEntryFromRow(Data.itemRarity, 0, "text", fdd_ItemRarity.GetText()));
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.TypeFilters == null)
                    queryFilters.TypeFilters = new TypeFilters();

                if (queryFilters.TypeFilters.Filters == null)
                    queryFilters.TypeFilters.Filters = new TypeFiltersFilters();

                queryFilters.TypeFilters.Filters.Rarity = new Status();
                queryFilters.TypeFilters.Filters.Rarity.Option = Data.GetEntryFromRow(Data.itemRarity, 0, "text", fdd_ItemRarity.GetText());
            }

            #region WEAPON FILTERS

            if (!f_Damage.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.WeaponFilters == null)
                {
                    queryFilters.WeaponFilters = new WeaponFilters();
                    queryFilters.WeaponFilters.Disabled = false;
                }

                if (queryFilters.WeaponFilters.Filters == null)
                    queryFilters.WeaponFilters.Filters = new WeaponFiltersFilters();

                queryFilters.WeaponFilters.Filters.Damage = Extensions.SetDataFromFilterControl(f_Damage);
            }

            if (!f_CriticalChance.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.WeaponFilters == null)
                {
                    queryFilters.WeaponFilters = new WeaponFilters();
                    queryFilters.WeaponFilters.Disabled = false;
                }

                if (queryFilters.WeaponFilters.Filters == null)
                    queryFilters.WeaponFilters.Filters = new WeaponFiltersFilters();

                queryFilters.WeaponFilters.Filters.Crit = Extensions.SetDataFromFilterControl(f_CriticalChance);
            }

            if (!f_PhysicalDPS.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.WeaponFilters == null)
                {
                    queryFilters.WeaponFilters = new WeaponFilters();
                    queryFilters.WeaponFilters.Disabled = false;
                }

                if (queryFilters.WeaponFilters.Filters == null)
                    queryFilters.WeaponFilters.Filters = new WeaponFiltersFilters();

                queryFilters.WeaponFilters.Filters.Pdps = Extensions.SetDataFromFilterControl(f_PhysicalDPS);
            }

            if (!f_APS.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.WeaponFilters == null)
                {
                    queryFilters.WeaponFilters = new WeaponFilters();
                    queryFilters.WeaponFilters.Disabled = false;
                }

                if (queryFilters.WeaponFilters.Filters == null)
                    queryFilters.WeaponFilters.Filters = new WeaponFiltersFilters();

                queryFilters.WeaponFilters.Filters.Aps = Extensions.SetDataFromFilterControl(f_APS);
            }
            if (!f_DPS.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.WeaponFilters == null)
                {
                    queryFilters.WeaponFilters = new WeaponFilters();
                    queryFilters.WeaponFilters.Disabled = false;
                }

                if (queryFilters.WeaponFilters.Filters == null)
                    queryFilters.WeaponFilters.Filters = new WeaponFiltersFilters();

                queryFilters.WeaponFilters.Filters.Dps = Extensions.SetDataFromFilterControl(f_DPS);
            }
            if (!f_ElementalDPS.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.WeaponFilters == null)
                {
                    queryFilters.WeaponFilters = new WeaponFilters();
                    queryFilters.WeaponFilters.Disabled = false;
                }

                if (queryFilters.WeaponFilters.Filters == null)
                    queryFilters.WeaponFilters.Filters = new WeaponFiltersFilters();

                queryFilters.WeaponFilters.Filters.Edps = Extensions.SetDataFromFilterControl(f_ElementalDPS);
            }

            // Disable groud if Expand is collapsed
            if (queryFilters.WeaponFilters != null)
            {
                if (!ec_WeaponFilters.isExpanded)
                    queryFilters.WeaponFilters.Disabled = true;
                else
                    queryFilters.WeaponFilters.Disabled = null;
            }

            #endregion WEAPON FILTERS

            #region ARMOUR FILTERS

            if (!f_Armour.IsEmpty())
            {
                CheckFilter(ref query, queryFilters, eQueryFilters.ArmourFilters);
                queryFilters.ArmourFilters.Filters.Ar = Extensions.SetDataFromFilterControl(f_Armour);
            }

            if (!f_Block.IsEmpty())
            {
                CheckFilter(ref query, queryFilters, eQueryFilters.ArmourFilters);
                queryFilters.ArmourFilters.Filters.Block = Extensions.SetDataFromFilterControl(f_Block);
            }

            if (!f_Evasion.IsEmpty())
            {
                CheckFilter(ref query, queryFilters, eQueryFilters.ArmourFilters);
                queryFilters.ArmourFilters.Filters.Ev = Extensions.SetDataFromFilterControl(f_Evasion);
            }

            if (!f_EnergyShield.IsEmpty())
            {
                CheckFilter(ref query, queryFilters, eQueryFilters.ArmourFilters);
                queryFilters.ArmourFilters.Filters.Es = Extensions.SetDataFromFilterControl(f_EnergyShield);
            }
            // Disable groud if Expand is collapsed
            if (queryFilters.ArmourFilters != null)
            {
                if (!ec_ArmourFilters.isExpanded)
                    queryFilters.ArmourFilters.Disabled = true;
                else
                    queryFilters.ArmourFilters.Disabled = null;
            }

            #endregion ARMOUR FILTERS

            #region SOCKET FILTERS

            if (!f_Sockets.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.SocketFilters == null)
                {
                    queryFilters.SocketFilters = new SocketFilters();
                    queryFilters.SocketFilters.Disabled = false;
                }

                if (queryFilters.SocketFilters.Filters == null)
                    queryFilters.SocketFilters.Filters = new SocketFiltersFilters();

                if (queryFilters.SocketFilters.Filters.Sockets == null)
                    queryFilters.SocketFilters.Filters.Sockets = new Links();

                queryFilters.SocketFilters.Filters.Sockets = f_Sockets.SetDataFromControlSocketFilter();
            }

            if (!f_Links.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.SocketFilters == null)
                {
                    queryFilters.SocketFilters = new SocketFilters();
                    queryFilters.SocketFilters.Disabled = false;
                }

                if (queryFilters.SocketFilters.Filters == null)
                    queryFilters.SocketFilters.Filters = new SocketFiltersFilters();

                if (queryFilters.SocketFilters.Filters.Links == null)
                    queryFilters.SocketFilters.Filters.Links = new Links();

                queryFilters.SocketFilters.Filters.Links = f_Links.SetDataFromControlSocketFilter();
            }

            #endregion SOCKET FILTERS

            #region REQUIREMENT FILTERS

            if (!f_Level.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.ReqFilters == null)
                {
                    queryFilters.ReqFilters = new ReqFilters();
                    queryFilters.ReqFilters.Disabled = false;
                }

                if (queryFilters.ReqFilters.Filters == null)
                    queryFilters.ReqFilters.Filters = new ReqFiltersFilters();

                queryFilters.ReqFilters.Filters.Lvl = Extensions.SetDataFromFilterControl(f_Level);
            }

            if (!f_Strength.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.ReqFilters == null)
                {
                    queryFilters.ReqFilters = new ReqFilters();
                    queryFilters.ReqFilters.Disabled = false;
                }

                if (queryFilters.ReqFilters.Filters == null)
                    queryFilters.ReqFilters.Filters = new ReqFiltersFilters();

                queryFilters.ReqFilters.Filters.Str = Extensions.SetDataFromFilterControl(f_Strength);
            }

            if (!f_Dexterity.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.ReqFilters == null)
                {
                    queryFilters.ReqFilters = new ReqFilters();
                    queryFilters.ReqFilters.Disabled = false;
                }

                if (queryFilters.ReqFilters.Filters == null)
                    queryFilters.ReqFilters.Filters = new ReqFiltersFilters();

                queryFilters.ReqFilters.Filters.Dex = Extensions.SetDataFromFilterControl(f_Dexterity);
            }

            if (!f_Intelligence.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.ReqFilters == null)
                {
                    queryFilters.ReqFilters = new ReqFilters();
                    queryFilters.ReqFilters.Disabled = false;
                }

                if (queryFilters.ReqFilters.Filters == null)
                    queryFilters.ReqFilters.Filters = new ReqFiltersFilters();

                queryFilters.ReqFilters.Filters.Int = Extensions.SetDataFromFilterControl(f_Intelligence);
            }

            // Disable groud if Expand is collapsed
            if (queryFilters.ReqFilters != null)
            {
                if (!ec_Requirements.isExpanded)
                    queryFilters.ReqFilters.Disabled = true;
                else
                    queryFilters.ReqFilters.Disabled = null;
            }

            #endregion REQUIREMENT FILTERS

            #region MAP FILTERS

            if (!f_MapTier.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MapFilters == null)
                {
                    queryFilters.MapFilters = new MapFilters();
                    queryFilters.MapFilters.Disabled = false;
                }

                if (queryFilters.MapFilters.Filters == null)
                    queryFilters.MapFilters.Filters = new MapFiltersFilters();

                queryFilters.MapFilters.Filters.MapTier = Extensions.SetDataFromFilterControl(f_MapTier);
            }

            if (!f_MapPacksize.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MapFilters == null)
                {
                    queryFilters.MapFilters = new MapFilters();
                    queryFilters.MapFilters.Disabled = false;
                }

                if (queryFilters.MapFilters.Filters == null)
                    queryFilters.MapFilters.Filters = new MapFiltersFilters();

                queryFilters.MapFilters.Filters.MapPacksize = Extensions.SetDataFromFilterControl(f_MapPacksize);
            }

            if (!f_MapIIQ.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MapFilters == null)
                {
                    queryFilters.MapFilters = new MapFilters();
                    queryFilters.MapFilters.Disabled = false;
                }

                if (queryFilters.MapFilters.Filters == null)
                    queryFilters.MapFilters.Filters = new MapFiltersFilters();

                queryFilters.MapFilters.Filters.MapIiq = Extensions.SetDataFromFilterControl(f_MapIIQ);
            }

            if (!f_MapIIR.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MapFilters == null)
                {
                    queryFilters.MapFilters = new MapFilters();
                    queryFilters.MapFilters.Disabled = false;
                }

                if (queryFilters.MapFilters.Filters == null)
                    queryFilters.MapFilters.Filters = new MapFiltersFilters();

                queryFilters.MapFilters.Filters.MapIir = Extensions.SetDataFromFilterControl(f_MapIIR);
            }

            if (!fdd_ShaperMap.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MapFilters == null)
                {
                    queryFilters.MapFilters = new MapFilters();
                    queryFilters.MapFilters.Disabled = false;
                }

                if (queryFilters.MapFilters.Filters == null)
                    queryFilters.MapFilters.Filters = new MapFiltersFilters();

                queryFilters.MapFilters.Filters.MapShaped = new Status();
                queryFilters.MapFilters.Filters.MapShaped.Option = fdd_ShaperMap.GetTrueFalse();

                Statistics.PostStat("Shaped Map : " + fdd_ShaperMap.GetText(), "mapfilters");
            }
            if (!fdd_ElderMap.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MapFilters == null)
                {
                    queryFilters.MapFilters = new MapFilters();
                    queryFilters.MapFilters.Disabled = false;
                }

                if (queryFilters.MapFilters.Filters == null)
                    queryFilters.MapFilters.Filters = new MapFiltersFilters();

                queryFilters.MapFilters.Filters.MapElder = new Status();
                queryFilters.MapFilters.Filters.MapElder.Option = fdd_ElderMap.GetTrueFalse();
                Statistics.PostStat("Elder Map : " + fdd_ElderMap.GetText(), "mapfilters");
            }

            if (!fdd_MapSeries.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MapFilters == null)
                {
                    queryFilters.MapFilters = new MapFilters();
                    // queryFilters.MapFilters.Disabled = false;
                }

                if (queryFilters.MapFilters.Filters == null)
                    queryFilters.MapFilters.Filters = new MapFiltersFilters();

                queryFilters.MapFilters.Filters.MapSeries = new Status();

                queryFilters.MapFilters.Filters.MapSeries.Option = Data.GetEntryFromRow(Data.mapSeries, 1, "name", fdd_MapSeries.GetText());
                Console.WriteLine(Data.GetEntryFromRow(Data.mapSeries, 1, "name", fdd_MapSeries.GetText()));
                Statistics.PostStat("Altas Version : " + fdd_MapSeries.GetText(), "mapfilters");
            }

            // Disable groud if Expand is collapsed
            if (queryFilters.MapFilters != null)
            {
                if (!ec_MapFilters.isExpanded)
                    queryFilters.MapFilters.Disabled = true;
                else
                    queryFilters.MapFilters.Disabled = null;
            }

            #endregion MAP FILTERS

            #region MISC FILTERS

            if (!f_Quality.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Quality = Extensions.SetDataFromFilterControl(f_Quality);
            }

            if (!f_ItemLevel.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Ilvl = Extensions.SetDataFromFilterControl(f_ItemLevel);
            }

            if (!f_GemLevel.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.GemLevel = Extensions.SetDataFromFilterControl(f_GemLevel);
            }

            if (!f_GemExperience.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.GemLevelProgress = Extensions.SetDataFromFilterControl(f_GemExperience);
            }

            if (!fdd_ShaperInfluence.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.ShaperItem = new Status();
                queryFilters.MiscFilters.Filters.ShaperItem.Option = fdd_ShaperInfluence.GetTrueFalse();

                Statistics.PostStat("Shaper Influenced : " + fdd_ShaperInfluence.GetText(), "miscfilters");
            }

            if (!fdd_ElderInfluence.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.ElderItem = new Status();
                queryFilters.MiscFilters.Filters.ElderItem.Option = fdd_ElderInfluence.GetTrueFalse();

                Statistics.PostStat("Elder Influenced : " + fdd_ElderInfluence.GetText(), "miscfilters");
            }

            if (!fdd_CrusaderIfluence.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.CrusaderItem = new Status();
                queryFilters.MiscFilters.Filters.CrusaderItem.Option = fdd_CrusaderIfluence.GetTrueFalse();

                Statistics.PostStat("Crusader Influenced : " + fdd_CrusaderIfluence.GetText(), "miscfilters");
            }

            if (!fdd_HunterInfluence.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.HunterItem = new Status();
                queryFilters.MiscFilters.Filters.HunterItem.Option = fdd_HunterInfluence.GetTrueFalse();

                Statistics.PostStat("Hunter Influenced : " + fdd_HunterInfluence.GetText(), "miscfilters");
            }

            if (!fdd_RedeemerInfluence.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.RedeemerItem = new Status();
                queryFilters.MiscFilters.Filters.RedeemerItem.Option = fdd_RedeemerInfluence.GetTrueFalse();

                Statistics.PostStat("Redeemer Influenced : " + fdd_RedeemerInfluence.GetText(), "miscfilters");
            }

            if (!fdd_WarlordInfluence.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.WarlordItem = new Status();
                queryFilters.MiscFilters.Filters.WarlordItem.Option = fdd_WarlordInfluence.GetTrueFalse();

                Statistics.PostStat("Warlord Influenced : " + fdd_WarlordInfluence.GetText(), "miscfilters");
            }

            if (!fdd_FracturedItem.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Fractured = new Status();
                queryFilters.MiscFilters.Filters.Fractured.Option = fdd_FracturedItem.GetTrueFalse();

                Statistics.PostStat("Fractured item : " + fdd_FracturedItem.GetText(), "miscfilters");
            }

            if (!fdd_SynthesisedItem.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Synthesised = new Status();
                queryFilters.MiscFilters.Filters.Synthesised.Option = fdd_SynthesisedItem.GetTrueFalse();

                Statistics.PostStat("Synthesised item : " + fdd_SynthesisedItem.GetText(), "miscfilters");
            }

            if (!fdd_AlternateArt.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.AlternateArt = new Status();
                queryFilters.MiscFilters.Filters.AlternateArt.Option = fdd_AlternateArt.GetTrueFalse();

                Statistics.PostStat("Alternate Art : " + fdd_AlternateArt.GetText(), "miscfilters");
            }

            if (!fdd_Identified.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Identified = new Status();
                queryFilters.MiscFilters.Filters.Identified.Option = fdd_Identified.GetTrueFalse();

                Statistics.PostStat("Identified : " + fdd_Identified.GetText(), "miscfilters");
            }
            if (!fdd_Corrupted.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Corrupted = new Status();
                queryFilters.MiscFilters.Filters.Corrupted.Option = fdd_Corrupted.GetTrueFalse();

                Statistics.PostStat("Corrupted : " + fdd_Corrupted.GetText(), "miscfilters");
            }
            if (!fdd_Mirrored.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Mirrored = new Status();
                queryFilters.MiscFilters.Filters.Mirrored.Option = fdd_Mirrored.GetTrueFalse();

                Statistics.PostStat("Mirrored : " + fdd_Mirrored.GetText(), "miscfilters");
            }
            if (!fdd_Crafted.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Crafted = new Status();
                queryFilters.MiscFilters.Filters.Crafted.Option = fdd_Crafted.GetTrueFalse();

                Statistics.PostStat("Crafted : " + fdd_Crafted.GetText(), "miscfilters");
            }

            if (!fdd_Veiled.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Veiled = new Status();
                queryFilters.MiscFilters.Filters.Veiled.Option = fdd_Veiled.GetTrueFalse();

                Statistics.PostStat("Veiled : " + fdd_Veiled.GetText(), "miscfilters");
            }

            if (!fdd_Enchanted.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.Enchanted = new Status();
                queryFilters.MiscFilters.Filters.Enchanted.Option = fdd_Enchanted.GetTrueFalse();

                Statistics.PostStat("Enchanted : " + fdd_Enchanted.GetText(), "miscfilters");
            }

            if (!f_TalismanTier.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.MiscFilters == null)
                {
                    queryFilters.MiscFilters = new MiscFilters();
                    queryFilters.MiscFilters.Disabled = false;
                }

                if (queryFilters.MiscFilters.Filters == null)
                    queryFilters.MiscFilters.Filters = new MiscFiltersFilters();

                queryFilters.MiscFilters.Filters.TalismanTier = Extensions.SetDataFromFilterControl(f_TalismanTier);
            }

            // Disable groud if Expand is collapsed
            if (queryFilters.MiscFilters != null)
            {
                if (!ec_Miscellaneous.isExpanded)
                    queryFilters.MiscFilters.Disabled = true;
                else
                    queryFilters.MiscFilters.Disabled = null;
            }

            #endregion MISC FILTERS

            #region TRADE FILTERS

            if (!ft_Seller.IsEmpty())
            {
                if (query.Filters == null)
                    query.Filters = queryFilters;

                if (queryFilters.TradeFilters == null)
                {
                    queryFilters.TradeFilters = new TradeFilters();
                    //queryFilters.TradeFilters.Disabled = false;
                }
                if (queryFilters.TradeFilters.Filters == null)
                    queryFilters.TradeFilters.Filters = new TradeFiltersFilters();

                if (queryFilters.TradeFilters.Filters.Account == null)
                    queryFilters.TradeFilters.Filters.Account = new Queries.Account();

                queryFilters.TradeFilters.Filters.Account.Input = ft_Seller.GetText();
            }

            #endregion TRADE FILTERS

            TypeFilters tf = new TypeFilters();
            tf.Filters = new TypeFiltersFilters();

            tf.Filters.Rarity = new Status();
            if (!fdd_ItemRarity.IsEmpty() && fdd_ItemRarity.GetText() != "Any")
            {
                tf.Filters.Rarity.Option = Data.GetEntryFromRow(Data.itemRarity, 0, "text", fdd_ItemRarity.GetText());
                queryFilters.TypeFilters = tf;
            }

            searchQuery.Query = query; Status status = new Status();

            status.Option = "any"; // Any or Online (only)
            //status.Option = (cmb_accountStatus.SelectedIndex == 0) ? "any" : "online"; // Any or Online (only)

            List<Stat> stats = new List<Stat>();
            string pseudos = "";
            foreach (Control c in ec_Mods.DropZone.Controls)
            {
                if (c.GetType() == typeof(Filter_Mods))
                {
                    Filter_Mods fm = (Filter_Mods)c;
                    Console.WriteLine($"Type : {fm.type}, Min : {fm.Min}, Max : {fm.Max}");

                    Stat grp = new Stat();
                    grp.Type = fm.type;
                    if (grp.Type == "weight" || fm.type == "count")
                    {
                        grp.Value = new StatValue();
                        if (fm.Min != null)
                            grp.Value.Min = fm.Min.ToLong();
                        if (fm.Max != null)
                            grp.Value.Max = fm.Max.ToLong();
                    }

                    grp.Filters = new List<Queries.Filter>();

                    foreach (Filter_ModSearch fms in fm.GetMods())
                    {
                        if (string.IsNullOrEmpty(fms.mod))
                            continue;

                        string id = "";
                        string modText = fms.mod;
                        string type = modText.Between("[", "]");

                        string mod = modText.Substring(2 + type.Length);
                        string modId = Data.GetModIDWithType(mod, type);

                        if (type == "pseudo")
                            pseudos += modId + "|";

                        Queries.Filter filter = new Queries.Filter(modId);

                        if (fms.Min != null || fms.Max != null || fms.Weight != null)
                        {
                            filter.Value = new ModValue();

                            if (fms.Min != null)
                                filter.Value.Min = fms.Min.ToLong();

                            if (fms.Max != null)
                                filter.Value.Max = fms.Max.ToLong();

                            if (fms.isWeighted)
                                filter.Value.Weight = fms.Weight.ToLong();
                        }
                        grp.Filters.Add(filter);
                    }
                    stats.Add(grp);
                }
            }

            /*

            Stat modGroup = new Stat();
            modGroup.Filters = new List<Queries.Filter>();
            modGroup.Type = "and";
            stats.Add(modGroup);
            */
            searchQuery.Query.Stats = stats;
            searchQuery.Query.Status = status;

            searchQuery.Sort = sort;

            sort.Price = "asc";
            Console.WriteLine(searchQuery.ToJson());
            Query(searchQuery.ToJson(), null, pseudos, "", false, head);
            //NewQuery(searchQuery.ToJson(), null, "", "", false, "TEST");
        }

        private void CheckFilter(ref Query q, QueryFilters qf, eQueryFilters eqf = eQueryFilters.DontCheck)
        {
            if (q.Filters == null)
                q.Filters = qf;

            switch (eqf)
            {
                case eQueryFilters.DontCheck:
                    return;

                case eQueryFilters.ArmourFilters:
                    if (qf.ArmourFilters == null)
                    {
                        qf.ArmourFilters = new ArmourFilters();
                        qf.ArmourFilters.Disabled = false;
                    }
                    if (qf.ArmourFilters.Filters == null)
                        qf.ArmourFilters.Filters = new ArmourFiltersFilters();
                    break;
            }
        }

        public void PopulateControls()
        {
            List<string> items = new List<string>();
            foreach (DataRow dr in Data.itemRarity.Rows)
            {
                items.Add(dr[1].ToString());
            }
            fdd_ItemRarity.Items = items.ToArray();

            items = new List<string>();
            foreach (DataRow dr in Data.itemTypes.Rows)
            {
                items.Add(dr[1].ToString());
            }
            fdd_ItemCategory.Items = items.ToArray();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            foreach (Control c in flp_Search.Controls)
            {
                if (c.GetType() == typeof(ExpandCollapse))
                {
                    ExpandCollapse ec = (ExpandCollapse)c;
                    foreach (Control c1 in ec.DropZone.Controls)
                    {
                        if (c1.GetType() == typeof(Controls.Filter))
                        {
                            Controls.Filter f = (Controls.Filter)c1;
                            f.Reset();
                        }
                        if (c1.GetType() == typeof(Controls.Filter_DropDown))
                        {
                            Controls.Filter_DropDown fdd = (Controls.Filter_DropDown)c1;
                            fdd.Reset();
                        }
                        if (c1.GetType() == typeof(Controls.Filter_Sockets))
                        {
                            Controls.Filter_Sockets fs = (Controls.Filter_Sockets)c1;
                            fs.Reset();
                        }
                    }
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                btn_Close.Visible = true;
                btn_Reset.Visible = true;
                btn_Search.Visible = true;
                btn_CloseTab.Visible = false;
            }
            /*  This is for bulk
            else if (tabControl.SelectedIndex == 1)
            {
                btn_Close.Visible = true;
                btn_Reset.Visible = true;
                btn_Search.Visible = true;
                btn_CloseTab.Visible = false;
            }
            */
            else
            {
                btn_Close.Visible = true;
                btn_Reset.Visible = false;
                btn_Search.Visible = false;
                btn_CloseTab.Visible = true;
            }
        }

        private void Form_Search_Load(object sender, EventArgs e)
        {
        }

        private void Tb_itemSearch_TextChanged(object sender, EventArgs e)
        {
            string t = tb_ItemSearch.Text;

            if (t.Length > 1)
            {
                List<string> results = new List<string>();
                results = TextboxEvents.SearchDataTable(Data.items, 3, t.Replace("'", "%27"));
                lb_ItemSearch.Visible = (results.Count > 0) ? true : false;
                lb_ItemSearch.Items.Clear();

                foreach (string result in results)
                {
                    lb_ItemSearch.Items.Add(result.Replace("%27", "'"));
                }

                if (results.Count > 14)
                    lb_ItemSearch.Size = new System.Drawing.Size(lb_ItemSearch.Width, 15 * lb_ItemSearch.ItemHeight);
                else
                    lb_ItemSearch.Size = new System.Drawing.Size(lb_ItemSearch.Width, results.Count * lb_ItemSearch.ItemHeight);

                if (lb_ItemSearch.Items.Count > 0)
                    lb_ItemSearch.SelectedIndex = 0;
            }
            else
            {
                lb_ItemSearch.Visible = false;
                lb_ItemSearch.Items.Clear();
            }
        }

        private void tb_SearchItem_Leave(object sender, EventArgs e)
        {
            if (!lb_ItemSearch.Focused)
            {
                lb_ItemSearch.Items.Clear();
                lb_ItemSearch.Visible = false;
            }
        }

        private void lb_SearchItem_MouseDown(object sender, MouseEventArgs e)
        {
            if (lb_ItemSearch.SelectedIndex != -1)
                tb_ItemSearch.Text = lb_ItemSearch.Items[lb_ItemSearch.SelectedIndex].ToString();

            lb_ItemSearch.Visible = false;
            tb_ItemSearch.Focus();
        }

        // Cycle through Listbox with up - down, enter to set tb text from lb
        private void Tb_ItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                if (lb_ItemSearch.Visible)
                {
                    if (lb_ItemSearch.Items.Count > 0)
                    {
                        int index = lb_ItemSearch.SelectedIndex;

                        if (e.KeyCode == Keys.Up)
                            index--;
                        else
                            index++;

                        if (index < 0)
                            index = lb_ItemSearch.Items.Count - 1;
                        else if (index > lb_ItemSearch.Items.Count - 1)
                            index = 0;
                        lb_ItemSearch.SelectedIndex = index;
                    }
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (lb_ItemSearch.Visible)
                {
                    if (lb_ItemSearch.Items.Count > 0)
                    {
                        if (lb_ItemSearch.SelectedIndex != -1)
                        {
                            tb_ItemSearch.Text = lb_ItemSearch.Items[lb_ItemSearch.SelectedIndex].ToString();

                            lb_ItemSearch.Visible = false;
                            tb_ItemSearch.Focus();
                        }
                    }
                }
            }
        }

        private void Btn_AddModgroup_Click(object sender, EventArgs e)
        {
            AddModGroup("and");
            CalculateModCollapse();
        }

        private void btn_CloseTab_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
                return;

            TabWithQuery tab = (TabWithQuery)tabControl.SelectedTab;
            FlowLayoutPanel _flp = tab.GetFLP();

            foreach (Control c in _flp.Controls)
            {
                Console.WriteLine(c.GetType().ToString());
                if (c.GetType() == typeof(Ctrl_ResultDisplay))
                {
                    Ctrl_ResultDisplay crd = (Ctrl_ResultDisplay)c;
                    crd.TrashIt();
                }
            }
            tabControl.TabPages.Remove(tab);
            GC.Collect();
        }
    }

    public enum eQueryFilters
    {
        DontCheck,
        WeaponFilters,
        ArmourFilters,
        TypeFilters,
        Damage
    }
}