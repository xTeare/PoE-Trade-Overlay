using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class Filter_DropDown : UserControl
    {
        [Category("Design")]
        public string Header
        {
            get { return lbl_FilterName.Text; }
            set { lbl_FilterName.Text = value; }
        }

        private Image influenceImage;

        [Category("Design")]
        public Image InfluenceImage
        {
            get { return influenceImage; }
            set
            {
                influenceImage = value;
                pictureBox1.Image = influenceImage;
            }
        }

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

        public Color ForeColor_Label;
        public Color ForeColor_Dropdown;

        public Color BackColor_Label;
        public Color BackColor_DropDown;
        public Color BackColor_Button;
        public Color Border;
        public Color Arrow_Active;
        public Color Arrow_Inactive;

        public Filter_DropDown()
        {
            InitializeComponent();
            combo.Items.Clear();
            foreach (string str in Items)
            {
                combo.Items.Add(str);
            }
            if (combo.Items.Count != 0)
                combo.SelectedIndex = 0;
        }

        private void lbl_FilterName_Click(object sender, EventArgs e)
        {
            combo.SelectedIndex = (combo.SelectedIndex == combo.Items.Count - 1) ? 0 : combo.SelectedIndex + 1;
        }

        public void Reset()
        {
            combo.SelectedIndex = 0;
        }

        public bool IsEmpty()
        {
            return (combo.SelectedIndex != 0) ? false : true;
        }

        public string GetTrueFalse()
        {
            return (combo.Items[combo.SelectedIndex].ToString() == "Yes") ? "true" : "false";
        }

        public string GetText()
        {
            return combo.Items[combo.SelectedIndex].ToString();
        }

        public int GetIndex()
        {
            return combo.SelectedIndex;
        }

        private void lbl_FilterName_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                combo.SelectedIndex = (combo.SelectedIndex < combo.Items.Count - 1) ? combo.SelectedIndex + 1 : 0;
            else if ( e.Button == MouseButtons.Right)

                combo.SelectedIndex = (combo.SelectedIndex > 0) ? combo.SelectedIndex - 1 : combo.Items.Count - 1;
        }
    }
}