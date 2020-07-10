using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Filter_Sockets : UserControl
    {
        [Description("Header Text"), Category("Data")]
        public string Header
        {
            get { return lbl_FilterName.Text; }
            set { lbl_FilterName.Text = value; }
        }

        public Filter_Sockets()
        {
            InitializeComponent();

            tb_R.LostFocus += new EventHandler(TextboxEvents.PlaceRGBW);
            tb_G.LostFocus += new EventHandler(TextboxEvents.PlaceRGBW);
            tb_B.LostFocus += new EventHandler(TextboxEvents.PlaceRGBW);
            tb_W.LostFocus += new EventHandler(TextboxEvents.PlaceRGBW);
            tb_R.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_G.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_B.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_W.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_R.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
            tb_G.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
            tb_B.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
            tb_W.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);

            tb_min.LostFocus += new EventHandler(TextboxEvents.PlaceMinMax);
            tb_min.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_min.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);

            tb_max.LostFocus += new EventHandler(TextboxEvents.PlaceMinMax);
            tb_max.GotFocus += new EventHandler(TextboxEvents.RemovePlaceholder);
            tb_max.KeyDown += new KeyEventHandler(TextboxEvents.PreventEnter);
        }

        public bool IsEmpty()
        {
            bool isEmpty = true;

            if (tb_min.Text != "min" && tb_min.Text != "0" && tb_min.Text != string.Empty)
                isEmpty = false;

            if (tb_max.Text != "max" && tb_max.Text != "0" && tb_max.Text != string.Empty)
                isEmpty = false;

            if (tb_R.Text != "R" && tb_R.Text.IsNumber() && tb_R.Text != string.Empty)
                isEmpty = false;

            if (tb_G.Text != "G" && tb_G.Text.IsNumber() && tb_G.Text != string.Empty)
                isEmpty = false;

            if (tb_B.Text != "B" && tb_B.Text.IsNumber() && tb_B.Text != string.Empty)
                isEmpty = false;

            if (tb_W.Text != "W" && tb_W.Text.IsNumber() && tb_W.Text != string.Empty)
                isEmpty = false;

            return isEmpty;
        }

        public void Reset()
        {
            tb_min.Text = "min";
            tb_min.ForeColor = Constants.Placeholder;
            tb_max.Text = "max";
            tb_max.ForeColor = Constants.Placeholder;
            tb_R.Text = "R";
            tb_R.ForeColor = Constants.Placeholder;
            tb_G.Text = "G";
            tb_G.ForeColor = Constants.Placeholder;
            tb_B.Text = "B";
            tb_B.ForeColor = Constants.Placeholder;
            tb_W.Text = "W";
            tb_W.ForeColor = Constants.Placeholder;
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

        public string GetR()
        {
            if (tb_R.Text != string.Empty)
            {
                if (tb_R.Text != "R")
                    if (tb_R.Text.IsNumber())
                        return tb_R.Text;
            }
            return null;
        }

        public string GetG()
        {
            if (tb_G.Text != string.Empty)
            {
                if (tb_G.Text != "G")
                    if (tb_G.Text.IsNumber())
                        return tb_G.Text;
            }
            return null;
        }

        public string GetB()
        {
            if (tb_B.Text != string.Empty)
            {
                if (tb_B.Text != "B")
                    if (tb_B.Text.IsNumber())
                        return tb_B.Text;
            }
            return null;
        }

        public string GetW()
        {
            if (tb_W.Text != string.Empty)
            {
                if (tb_W.Text != "W")
                    if (tb_W.Text.IsNumber())
                        return tb_W.Text;
            }
            return null;
        }
    }
}