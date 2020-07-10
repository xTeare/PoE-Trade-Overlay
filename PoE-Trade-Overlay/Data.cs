using PoE_Trade_Overlay.Queries;
using PoE_Trade_Overlay.Queries.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;

namespace PoE_Trade_Overlay
{
    public static class Data
    {
        public static Leagues leagues;
        public static DataTable items;
        public static DataTable stats;
        public static DataTable currency;
        public static DataTable mapSeries;
        public static DataTable currencyRates;
        public static DataTable itemTypes = new DataTable();
        public static DataTable itemRarity = new DataTable();
        public static bool PriceInChaosEnabled = false;

        public static DataTable socketPositions = new DataTable();

        public static List<string> modsWithReduced = new List<string>();
        public static List<KeyValuePair<string, Image>> loadedCurrency = new List<KeyValuePair<string, Image>>();

        private static CurrencyData currencyData;

        public static void Load()
        {
            socketPositions = ConvertToDataTable("Data/socketspacing.txt", new string[] { "id", "x", "y" });
            itemTypes = ConvertToDataTable("Data/types.txt", new string[] { "id", "text" });
            itemRarity = ConvertToDataTable("Data/rarity.txt", new string[] { "id", "text" });
            mapSeries = ConvertToDataTable("Data/mapSeries.txt", new string[] { "name", "id" });
        }

        public static void LoadLeagues()
        {
            leagues = Leagues.FromJson((string)QueryHelper.GetWebRequest("http://www.pathofexile.com/api/trade/data/leagues"));
        }

        public static string GetChaosEquivalent(string source)
        {
            foreach (DataRow dr in currencyRates.Rows)
            {
                if (dr[0].ToString() == source)
                    return dr[1].ToString();
            }
            return "";
        }

        public static string GetEntryFromRow(DataTable tbl, int columnIndex, string columnToSearch, string search)
        {
            string str = string.Empty;
            try
            {
                DataRow[] rows = tbl.Select(columnToSearch + " = '" + search + "'");
                if (rows.Length != 0)
                {
                    str = rows[0][columnIndex].ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Data:GetEntryFromRow Exception : " + e.Message);
            }
            return str;
        }

        public static string GetFullCurrencyName(this string source)
        {
            try
            {
                foreach (DataRow dr in currency.Rows)
                    if (dr[0].ToString() == source)
                        return dr[1].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Poe_Trade_Overlay::Data.GetFullCurrencyName() Exception {e.Source}, Message : {e.Message}");
            }
            return "";
        }

        public static string GetModIDWithType(string text, string type)
        {
            foreach (DataRow dr in Data.stats.Rows)
            {
                if (dr[1].ToString() == text && dr[2].ToString() == type)
                    return dr[0].ToString();
            }
            return null;
        }


        public static string GetModID(string text)
        {
            foreach (DataRow dr in Data.stats.Rows)
            {
                if (dr[1].ToString() == text)
                    return dr[0].ToString();
            }
            return "";
        }

        public static void LoadItemCategories(this System.Windows.Forms.ComboBox.ObjectCollection objectCollection)
        {
            foreach (DataRow dr in itemTypes.Rows)
            {
                objectCollection.Add(dr[1].ToString());
            }
        }

        public static bool LoadItems()
        {
            try
            {
                // Parse Item Data
                Items item = Items.FromJson((string)QueryHelper.GetWebRequest("http://www.pathofexile.com/api/trade/data/items"));

                string fileContents = "";

                foreach (ItemResult result in item.Result)
                {
                    foreach (ItemEntry e in result.Entries)
                    {
                        if (result.Label == "Maps")
                        {
                            if (e.Flags != null)
                            {
                                string s2 = e.Text.Replace(e.Name + " ", "").Replace("'", "%27");
                                fileContents += string.Format("{0}|{1}\n", e.Name.Replace("'", "%27"), s2);
                            }
                            else
                            {
                                string s3 = e.Type.Replace("'", "%27"); // Academy Map
                                string s4 = e.Text.Replace("'", "%27"); // Academy Map (War for the Atlas)
                                fileContents += string.Format("{0}|{1}\n", e.Type.Replace("'", "%27"), s4.Replace(s3 + " ", ""));
                            }
                        }
                        else
                        {
                            if (e.Name != null) // since we dont have an item Name its just a base (eg. Paua Amulet)
                            {
                                fileContents += string.Format("{0}|{1}|{2}\n", e.Name.Replace("'", "%27"), e.Type.Replace("'", "%27"), e.Text.Replace("'", "%27"));
                            }
                            else
                            {
                                fileContents += string.Format("{0}|{1}\n", e.Type.Replace("'", "%27"), e.Text.Replace("'", "%27"));
                            }
                        }
                    }
                }

                File.WriteAllText("data/items.txt", fileContents);
                items = ConvertToDataTable("data/items.txt", new string[] { "name", "type", "text", "combined" });
            }
            catch (Exception e)
            {
                Console.WriteLine("Data::LoadItems() Exception : " + e.Message);
                return false;
            }
            return true;
        }

        public static bool LoadStats()
        {
            try
            {
                Stats stat = Stats.FromJson((string)QueryHelper.GetWebRequest("https://www.pathofexile.com/api/trade/data/stats"));
                string fileContents = "";
                foreach (StatResult result in stat.Result)
                {
                    foreach (StatEntry e in result.Entries)
                    {
                        if (!e.Text.Contains("\n"))
                            fileContents += string.Format("{0}|{1}|{2}\n", e.Id, e.Text, e.Type);
                        if (e.Text.Contains("reduced"))
                            modsWithReduced.Add(e.Text);
                    }
                }
                File.WriteAllText("data/mods.txt", fileContents);
                stats = ConvertToDataTable("data/mods.txt", new string[] { "id", "text", "type" });
            }
            catch (Exception e)
            {
                Console.WriteLine("Data::LoadStats() Exception : " + e.Message);
                return false;
            }
            return true;
        }

        private static void DownloadItemArt(string art, string id)
        {
            Uri uri = new Uri("http://web.poecdn.com" + art);
            string folder = Path.GetDirectoryName("Data/Images/" + art.Between("2DItems", "?v=")) + @"\";
            string file = Path.GetFileName(art).Between("", "?v=");
            CreateFolder(folder);

            if (!File.Exists(folder + file))
                using (var client = new WebClient())
                    client.DownloadFile(uri, folder + file);

            if (File.Exists(folder + file))
            {
                using (FileStream stream = new FileStream(folder + file, FileMode.Open, FileAccess.Read))
                {
                    Image image = Image.FromStream(stream);
                    loadedCurrency.Add(new KeyValuePair<string, Image>(id, image));
                }
            }
        }

        public static Image GetCurrencyImage(string id)
        {
            foreach (KeyValuePair<string, Image> pair in loadedCurrency)
                if (pair.Key == id)
                    return pair.Value;
            return null;
        }

        public static bool LoadCurrency()
        {
            try
            {
                string filecontents = "";

                CreateFolder("Data");
                CreateFolder("Data/Images");

                // Download Currency Data
                CurrencyData currencyData = CurrencyData.FromJson((string)QueryHelper.GetWebRequest("https://www.pathofexile.com/api/trade/data/static"));

                // Iterate Data
                foreach (CurrencyDataResult cdresult in currencyData.Result)
                {
                    foreach (CurrencyDataEntry cdentry in cdresult.Entries)
                    {
                        if (cdentry.Image == null || !cdentry.Image.Contains(".png"))
                            continue;

                        filecontents += $"{cdentry.Id}|{cdentry.Text}|{cdentry.Image.Between("", "?v=")}\n";
                        DownloadItemArt(cdentry.Image, cdentry.Id);
                    }
                }

                // Write to File
                File.WriteAllText("Data/Currency.txt", filecontents);

                // Load into DataTable
                Data.currency = ConvertToDataTable("Data/Currency.txt", new string[] { "id", "text", "url" });
            }
            catch (Exception e)
            {
                Console.WriteLine("Data.LoadCurreny() Exception :" + e.Message);
                return false;
            }
            return true;
        }

        private static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static DataTable ConvertToDataTable(string filePath, string[] columns)
        {
            DataTable tbl = new DataTable();
            foreach (string str in columns)
            {
                tbl.Columns.Add(new DataColumn(str));
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var cols = line.Split('|');

                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < columns.Length; cIndex++)
                {
                    if (cols.Length >= cIndex + 1)
                        dr[cIndex] = cols[cIndex];

                    if (filePath == "data/items.txt")
                    {
                        if (cols[0] != cols[1])
                            dr[3] = cols[0] + " " + cols[1];
                        else
                            dr[3] = cols[0];
                    }
                }
                tbl.Rows.Add(dr);
            }

            return tbl;
        }
    }
}