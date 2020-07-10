using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay
{
    public static class TextboxEvents
    {
        public static void PreventEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public static void PreventOnlyEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public static void PlaceMinMax(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == string.Empty)
            {
                if (tb.Name.Contains("min") || tb.Name.Contains("max")) //weight
                {
                    Color fc = Constants.Placeholder;

                    tb.ForeColor = fc;
                    tb.Text = (tb.Name.Contains("min")) ? "min" : "max";
                }
            }
        }

        public static void PlaceWeight(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == string.Empty)
            {
                tb.ForeColor = Constants.Placeholder;
                tb.Text = "weight";
            }
        }

        public static void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "min" || tb.Text == "max" || tb.Text == "weight" || tb.Name.Contains("_R") || tb.Name.Contains("_G") || tb.Name.Contains("_B") || tb.Name.Contains("_W"))
            {
                Color fc = Constants.Fore;

                tb.ForeColor = fc;
                tb.Text = string.Empty;
            }
        }

        public static void PlaceRGBW(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == string.Empty)
            {
                if (tb.Name.Contains("_R") || tb.Name.Contains("_G") || tb.Name.Contains("_B") || tb.Name.Contains("_W"))
                {
                    tb.ForeColor = Constants.Placeholder;
                    if (tb.Name.Contains("_R"))
                        tb.Text = "R";
                    if (tb.Name.Contains("_G"))
                        tb.Text = "G";
                    if (tb.Name.Contains("_B"))
                        tb.Text = "B";
                    if (tb.Name.Contains("_W"))
                        tb.Text = "W";
                }
            }
        }

        public static List<string> SearchDataTable(DataTable dataTable, int column, string key)
        {
            List<string> results = new List<string>();

            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr[column].ToString().BetterContains(key, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(dr[column].ToString());
                }
            }

            return results;
        }

        public static List<string> SearchDataTableMods(DataTable dataTable, int column, string key)
        {
            List<string> results = new List<string>();

            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr[column].ToString().BetterContains(key, StringComparison.OrdinalIgnoreCase))
                {
                    string addition = "";
                    if (dataTable == Data.stats)
                        if (dr[2].ToString() != string.Empty)
                            addition = $"[{dr[2]}]";
                    results.Add(addition + dr[column].ToString());
                }
            }

            return results;
        }
    }
}