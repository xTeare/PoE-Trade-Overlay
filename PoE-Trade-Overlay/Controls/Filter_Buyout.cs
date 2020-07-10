using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Filter_Buyout : UserControl
    {
        [Category("Design")]
        public string[] Items
        {
            get
            {
                List<string> str = new List<string>();
                foreach (object obj in combo.Items)
                {
                    str.Add(obj.ToString());
                }
                return str.ToArray();
            }

            set
            {
                combo.Items.Clear();
                foreach (string st in value)
                {
                    combo.Items.Add(st);
                }
                if (combo.Items.Count != 0)
                    combo.SelectedIndex = 0;
            }
        }

        public Filter_Buyout()
        {
            InitializeComponent();
        }

        private void lbl_FilterName_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
                combo.SelectedIndex = (combo.SelectedIndex < combo.Items.Count - 1) ? combo.SelectedIndex + 1 : 0;
            else if (e.Button == MouseButtons.Right)
                tb_min.Focus();
            else if (e.Button == MouseButtons.Middle)
                tb_max.Focus();
        }
    }
}