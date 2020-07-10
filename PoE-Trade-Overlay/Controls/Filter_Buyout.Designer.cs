namespace PoE_Trade_Overlay.Controls
{
    partial class Filter_Buyout
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
            this.tb_max = new System.Windows.Forms.TextBox();
            this.tb_min = new System.Windows.Forms.TextBox();
            this.combo = new PoE_Trade_Overlay.Controls.FlattenCombo();
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
            this.lbl_FilterName.TabIndex = 24;
            this.lbl_FilterName.Text = "label1";
            this.lbl_FilterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_FilterName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_FilterName_MouseDown);
            // 
            // tb_max
            // 
            this.tb_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.tb_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_max.Font = new System.Drawing.Font("Consolas", 10F);
            this.tb_max.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.tb_max.Location = new System.Drawing.Point(545, 0);
            this.tb_max.Multiline = true;
            this.tb_max.Name = "tb_max";
            this.tb_max.Size = new System.Drawing.Size(45, 20);
            this.tb_max.TabIndex = 26;
            this.tb_max.Text = "max";
            this.tb_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_min
            // 
            this.tb_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.tb_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_min.Font = new System.Drawing.Font("Consolas", 10F);
            this.tb_min.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.tb_min.Location = new System.Drawing.Point(498, 0);
            this.tb_min.Multiline = true;
            this.tb_min.Name = "tb_min";
            this.tb_min.Size = new System.Drawing.Size(45, 20);
            this.tb_min.TabIndex = 25;
            this.tb_min.Text = "min";
            this.tb_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.combo.Size = new System.Drawing.Size(296, 22);
            this.combo.TabIndex = 27;
            // 
            // Filter_Buyout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.combo);
            this.Controls.Add(this.tb_max);
            this.Controls.Add(this.tb_min);
            this.Controls.Add(this.lbl_FilterName);
            this.Name = "Filter_Buyout";
            this.Size = new System.Drawing.Size(590, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_FilterName;
        private System.Windows.Forms.TextBox tb_max;
        private System.Windows.Forms.TextBox tb_min;
        private FlattenCombo combo;
    }
}
