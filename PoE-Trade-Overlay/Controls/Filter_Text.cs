using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Filter_Text : UserControl
    {
        [Category("Design")]
        public string Header
        {
            get { return lbl_FilterName.Text; }
            set { lbl_FilterName.Text = value; }
        }

        [Category("Design")]
        private string _placeholder;

        public string Placeholder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value;
                tb.Text = _placeholder;
                tb.ForeColor = Constants.Fore;
            }
        }

        public Filter_Text()
        {
            InitializeComponent();
            tb.GotFocus += Filter_Text_GotFocus;
            tb.LostFocus += Filter_Text_LostFocus;
        }

        private void Filter_Text_LostFocus(object sender, EventArgs e)
        {
            Console.WriteLine("LOST FOCUS");
            if (tb.Text == string.Empty || tb.Text == Placeholder)
            {
                tb.ForeColor = Constants.Placeholder;
            }
        }

        private void Filter_Text_GotFocus(object sender, EventArgs e)
        {
            Console.WriteLine("GOT FOCUS");
            if (tb.Text == string.Empty || tb.Text == Placeholder)
            {
                tb.ForeColor = Constants.Fore;
            }
        }

        public void Reset()
        {
            tb.Text = Placeholder;
            tb.ForeColor = Constants.Placeholder;
        }

        public bool IsEmpty()
        {
            if (tb.Text == string.Empty || tb.Text == Placeholder)
                return true;
            else
                return false;
        }

        public string GetText()
        {
            return tb.Text;
        }

        // Place / remove Placeholder
        private void Tb_TextChanged(object sender, EventArgs e)
        {
            if (tb.Text == string.Empty || tb.Text == Placeholder)
            {
                tb.ForeColor = Constants.Placeholder;
            }
        }
    }
}