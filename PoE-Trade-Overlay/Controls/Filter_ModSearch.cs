using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Filter_ModSearch : UserControl
    {
        public string mod;
        public string min;
        public string max;
        public string weight;
        public Filter_Mods parent;

        public bool isWeighted;


        public string Min
        {
            get { return (tb_min.Text == string.Empty || tb_min.Text == "min" || tb_min.Text == "0") ? null : tb_min.Text; }
        }

        public string Max
        {
            get { return (tb_max.Text == string.Empty || tb_max.Text == "max" || tb_max.Text == "0") ? null : tb_max.Text; }
        }
        public string Weight
        {
            get { return (tb_weight.Text == string.Empty || tb_weight.Text == "weight" || tb_weight.Text == "0") ? null : tb_weight.Text; }
        }

        public Filter_ModSearch()
        {
            InitializeComponent();

            tb_min.LostFocus += new EventHandler(TextboxEvents.PlaceMinMax);
            tb_min.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_min.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
            tb_max.LostFocus += new EventHandler(TextboxEvents.PlaceMinMax);
            tb_max.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_max.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
            tb_weight.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
        }

        public bool IsEmpty()
        {
            bool b = true;

            if (min != string.Empty)
                if (min.ToLong() != 0)
                    b = false;
            if (max != string.Empty)
                if (max.ToLong() != 0)
                    b = false;

            return b;
        }

        public bool isMinMaxEmpty()
        {
            bool b = true;

            if (min != string.Empty)
                if (min.ToLong() != 0)
                    b = false;
            if (max != string.Empty)
                if (max.ToLong() != 0)
                    b = false;

            return b;
        }

        public void SetWeighted(bool weight)
        {
            isWeighted = weight;
            tb_Mod.Size = (weight) ? new Size(374, 19) : new Size(442, 19);
            pictureBox1.Size = (weight) ? new Size(374, 1) : new Size(442, 1);
            tb_weight.Visible = weight;
        }

        private void Tb_Mod_TextChanged(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = (FlowLayoutPanel)this.Parent;

            // Only search if we have more than 2 letters to reduce input lag
            if (tb_Mod.Text.Length < 3)
            {
                lb_Mods.Visible = false;
                lb_Mods.Location = new Point(3, 3);
                flp.Refresh();
                Form_Search.instance.CalculateModCollapse();
                return;
            }

            lb_Mods.Location = new Point(3, 22);

            List<string> results = new List<string>();
            results = TextboxEvents.SearchDataTableMods(Data.stats, 1, tb_Mod.Text);

            lb_Mods.Items.Clear();

            foreach (string result in results)
                lb_Mods.Items.Add(result);

            if (lb_Mods.Items.Count > 0)
                lb_Mods.SelectedIndex = 0;

            if (results.Count > 14)
                lb_Mods.Size = new Size(lb_Mods.Width, 15 * lb_Mods.ItemHeight);
            else
                lb_Mods.Size = new Size(lb_Mods.Width, (lb_Mods.Items.Count + 1) * lb_Mods.ItemHeight);

            lb_Mods.Visible = (results.Count > 0) ? true : false;
            //height = lb_mods.Height;

            mod = tb_Mod.Text;
            Form_Search.instance.CalculateModCollapse();
        }

        private void Tb_Mod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                if (lb_Mods.Visible)
                {
                    if (lb_Mods.Items.Count > 0)
                    {
                        int index = lb_Mods.SelectedIndex;

                        if (e.KeyCode == Keys.Up)
                            index--;
                        else
                            index++;

                        if (index < 0)
                            index = lb_Mods.Items.Count - 1;
                        else if (index > lb_Mods.Items.Count - 1)
                            index = 0;
                        lb_Mods.SelectedIndex = index;
                    }
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (lb_Mods.Visible)
                {
                    if (lb_Mods.Items.Count > 0)
                    {
                        if (lb_Mods.SelectedIndex != -1)
                        {
                            tb_Mod.Text = lb_Mods.Items[lb_Mods.SelectedIndex].ToString();
                            mod = lb_Mods.Items[lb_Mods.SelectedIndex].ToString();
                            lb_Mods.Visible = false;
                            tb_Mod.Focus();
                            Form_Search.instance.CalculateModCollapse();
                        }
                    }
                }
            }
        }

        private void Lb_Mods_MouseDown(object sender, MouseEventArgs e)
        {
            if (lb_Mods.SelectedIndex != -1)
            {
                string t = lb_Mods.SelectedItem.ToString();
                tb_Mod.Text = t;
                mod         = t;
            }

            lb_Mods.Visible = false;
            tb_Mod.Focus();
            Form_Search.instance.CalculateModCollapse();
        }

        private void Tb_min_TextChanged(object sender, EventArgs e)
        {
            min = tb_min.Text;
        }

        private void Tb_max_TextChanged(object sender, EventArgs e)
        {
            max = tb_max.Text;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            parent.RemoveModSearch(this);
        }
    }
}