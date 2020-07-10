using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Filter_Mods : UserControl
    {
        private string _type;

        public string type
        {
            get { return _type; }
            set
            {
                _type = value;
                ShowHideControls();
                lbl_Type.Text = "Mod Group : " + value;

                combo.SelectedIndex = combo.Items.IndexOf(_type);
            }
        }

        public string Min
        {
            get { return (tb_min.Text == string.Empty || tb_min.Text == "max" || tb_min.Text == "0") ? null : tb_min.Text; }
        }

        public string Max
        {
            get { return (tb_max.Text == string.Empty || tb_max.Text == "max" || tb_max.Text == "0") ? null : tb_max.Text; }
        }

        public Filter_Mods()
        {
            InitializeComponent();
            tb_min.LostFocus += new EventHandler(TextboxEvents.PlaceMinMax);
            tb_min.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_min.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
            tb_max.LostFocus += new EventHandler(TextboxEvents.PlaceMinMax);
            tb_max.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_max.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
        }

        public void RemoveModSearch(Filter_ModSearch c)
        {
            flp.Controls.Remove(c);
            Form_Search.instance.CalculateModCollapse();
        }

        private void ShowHideControls()
        {
            if (type == "count" || type == "weight")
            {
                tb_min.Visible = true;
                tb_max.Visible = true;
            }
            else
            {
                tb_min.Visible = false;
                tb_max.Visible = false;
            }
        }

        public bool AllEmpty()
        {
            bool b = true;
            foreach (Control c in flp.Controls)
            {
                if (c.GetType() == typeof(Filter_ModSearch))
                {
                    Filter_ModSearch m = (Filter_ModSearch)c;
                    m.SetWeighted((type == "weight") ? true : false);
                }
            }
            return b;
        }

        public void AddSearch()
        {
            Filter_ModSearch m = new Filter_ModSearch();
            m.parent = this;

            if (type == "weight")
                m.SetWeighted(true);

            flp.Controls.Add(m);
            Form_Search.instance.CalculateModCollapse();
        }

        private void UpdateModSearches()
        {
            foreach (Control c in flp.Controls)
            {
                if (c.GetType() == typeof(Filter_ModSearch))
                {
                    Filter_ModSearch m = (Filter_ModSearch)c;
                    m.SetWeighted((type == "weight") ? true : false);
                }
            }
        }

        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo.SelectedIndex != -1)
            {
                type = (string)combo.Items[combo.SelectedIndex];
                UpdateModSearches();
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            AddSearch();
        }

        public List<Filter_ModSearch> GetMods()
        {
            List<Filter_ModSearch> l = new List<Filter_ModSearch>();
            foreach (Control c in flp.Controls)
                if (c.GetType() == typeof(Filter_ModSearch))
                    l.Add((Filter_ModSearch)c);
            return l;
        }

        private void btn_RemoveThis_Click(object sender, EventArgs e)
        {
            Form_Search.instance.RemoveModGroup(this);
        }
    }
}