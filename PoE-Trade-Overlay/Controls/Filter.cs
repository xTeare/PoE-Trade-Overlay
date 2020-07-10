using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Filter : UserControl
    {
        [Category("Design")]
        public string Header
        {
            get { return lbl_FilterName.Text; }
            set { lbl_FilterName.Text = value; }
        }

        public string QueryName
        {
            get { return queryName; }
            set { queryName = value; }
        }

        public string Min
        {
            get { return (tb_min.Text == string.Empty || tb_min.Text == "max" || tb_min.Text == "0") ? null : tb_min.Text; }
        }

        public string Max
        {
            get { return (tb_max.Text == string.Empty || tb_max.Text == "max" || tb_max.Text == "0") ? null : tb_max.Text; }
        }

        private string queryName;

        public Color ForeColor_Label;
        public Color ForeColor_Textbox;
        public Color BackColor_Label;
        public Color BackColor_Textbox;
        public Color ForeColor_Placeholder;

        public Filter()
        {
            InitializeComponent();
            tb_min.LostFocus += new EventHandler(TextboxEvents.PlaceMinMax);
            tb_min.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_min.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
            tb_max.LostFocus += new EventHandler(TextboxEvents.PlaceMinMax);
            tb_max.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_max.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
        }

        public void RefreshControls()
        {
            lbl_FilterName.ForeColor = ForeColor_Label;
            lbl_FilterName.BackColor = BackColor_Label;
            tb_min.BackColor = BackColor_Textbox;
            tb_max.BackColor = BackColor_Textbox;

            if (tb_min.Text == "min")
                tb_min.ForeColor = ForeColor_Placeholder;

            if (tb_max.Text == "max")
                tb_max.ForeColor = ForeColor_Placeholder;
        }

        public void Reset()
        {
            tb_min.Text = "min";
            tb_min.ForeColor = Constants.Placeholder;
            tb_max.Text = "max";
            tb_max.ForeColor = Constants.Placeholder;
        }

        public string GetMin()
        {
            if (tb_min.Text != string.Empty)
            {
                if (tb_min.Text != "min")
                    if (tb_min.Text != "0")
                        return tb_min.Text;
            }
            return null;
        }

        public string GetMax()
        {
            if (tb_max.Text != string.Empty)
            {
                if (tb_max.Text != "max")
                    if (tb_max.Text != "0")
                        return tb_max.Text;
            }
            return null;
        }

        public bool IsEmpty()
        {
            bool empty = true;

            if (tb_min.Text != "min" && tb_min.Text != "0" && tb_min.Text != string.Empty)
                empty = false;

            if (tb_max.Text != "max" && tb_max.Text != "0" && tb_max.Text != string.Empty)
                empty = false;

            return empty;
        }

        private void lbl_FilterName_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                tb_min.Focus();
            else if (e.Button == MouseButtons.Right)
                tb_max.Focus();
        }
    }
}