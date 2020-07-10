namespace PoE_Trade_Overlay.Controls
{
    partial class Filter_DropDown
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_FilterName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.combo = new PoE_Trade_Overlay.Controls.FlattenCombo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_FilterName
            // 
            this.lbl_FilterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.lbl_FilterName.Font = new System.Drawing.Font("Consolas", 9F);
            this.lbl_FilterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.lbl_FilterName.Location = new System.Drawing.Point(0, 0);
            this.lbl_FilterName.Name = "lbl_FilterName";
            this.lbl_FilterName.Size = new System.Drawing.Size(200, 21);
            this.lbl_FilterName.TabIndex = 23;
            this.lbl_FilterName.Text = "label1";
            this.lbl_FilterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_FilterName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FilterName_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.pictureBox1.Location = new System.Drawing.Point(177, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // combo
            // 
            this.combo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo.Arrow_Active = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.combo.Arrow_Inactive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.combo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.combo.BackColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.combo.BackColorButton = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(32)))));
            this.combo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.combo.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.combo.Data = null;
            this.combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo.Font = new System.Drawing.Font("Consolas", 9F);
            this.combo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.combo.ForeColorDrop = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.combo.FormattingEnabled = true;
            this.combo.Location = new System.Drawing.Point(200, 0);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(92, 22);
            this.combo.TabIndex = 22;
            // 
            // Filter_DropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_FilterName);
            this.Name = "Filter_DropDown";
            this.Size = new System.Drawing.Size(292, 20);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlattenCombo combo;
        private System.Windows.Forms.Label lbl_FilterName;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
