namespace PoE_Trade_Overlay.Controls
{
    partial class Filter_Mods
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
            this.tb_min = new System.Windows.Forms.TextBox();
            this.tb_max = new System.Windows.Forms.TextBox();
            this.lbl_Type = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_RemoveThis = new System.Windows.Forms.Button();
            this.combo = new PoE_Trade_Overlay.Controls.FlattenCombo();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_min
            // 
            this.tb_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.tb_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_min.Font = new System.Drawing.Font("Consolas", 10F);
            this.tb_min.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.tb_min.Location = new System.Drawing.Point(225, 4);
            this.tb_min.Multiline = true;
            this.tb_min.Name = "tb_min";
            this.tb_min.Size = new System.Drawing.Size(45, 20);
            this.tb_min.TabIndex = 2;
            this.tb_min.Text = "min";
            this.tb_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_max
            // 
            this.tb_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.tb_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_max.Font = new System.Drawing.Font("Consolas", 10F);
            this.tb_max.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.tb_max.Location = new System.Drawing.Point(276, 4);
            this.tb_max.Multiline = true;
            this.tb_max.Name = "tb_max";
            this.tb_max.Size = new System.Drawing.Size(45, 20);
            this.tb_max.TabIndex = 3;
            this.tb_max.Text = "max";
            this.tb_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Type
            // 
            this.lbl_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Type.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Type.Font = new System.Drawing.Font("Consolas", 9F);
            this.lbl_Type.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.lbl_Type.Location = new System.Drawing.Point(5, 0);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(591, 25);
            this.lbl_Type.TabIndex = 4;
            this.lbl_Type.Text = "Mod Group :";
            this.lbl_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(591, 1);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // flp
            // 
            this.flp.AutoSize = true;
            this.flp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp.Location = new System.Drawing.Point(3, 30);
            this.flp.MinimumSize = new System.Drawing.Size(585, 20);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(585, 20);
            this.flp.TabIndex = 6;
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(22)))));
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("Consolas", 9F);
            this.btn_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.btn_Add.Location = new System.Drawing.Point(481, 3);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(107, 23);
            this.btn_Add.TabIndex = 27;
            this.btn_Add.Text = "add modfilter";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // btn_RemoveThis
            // 
            this.btn_RemoveThis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RemoveThis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(22)))));
            this.btn_RemoveThis.FlatAppearance.BorderSize = 0;
            this.btn_RemoveThis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveThis.Font = new System.Drawing.Font("Consolas", 9F);
            this.btn_RemoveThis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.btn_RemoveThis.Location = new System.Drawing.Point(452, 2);
            this.btn_RemoveThis.Name = "btn_RemoveThis";
            this.btn_RemoveThis.Size = new System.Drawing.Size(23, 23);
            this.btn_RemoveThis.TabIndex = 29;
            this.btn_RemoveThis.Text = "X";
            this.btn_RemoveThis.UseVisualStyleBackColor = false;
            this.btn_RemoveThis.Click += new System.EventHandler(this.btn_RemoveThis_Click);
            // 
            // combo
            // 
            this.combo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.combo.Items.AddRange(new object[] {
            "and",
            "not",
            "if",
            "count",
            "weight"});
            this.combo.Location = new System.Drawing.Point(327, 3);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(119, 22);
            this.combo.TabIndex = 28;
            this.combo.SelectedIndexChanged += new System.EventHandler(this.Combo_SelectedIndexChanged);
            // 
            // Filter_Mods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.btn_RemoveThis);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.flp);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tb_max);
            this.Controls.Add(this.tb_min);
            this.Controls.Add(this.lbl_Type);
            this.MinimumSize = new System.Drawing.Size(590, 50);
            this.Name = "Filter_Mods";
            this.Size = new System.Drawing.Size(591, 53);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_min;
        private System.Windows.Forms.TextBox tb_max;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flp;
        private System.Windows.Forms.Button btn_Add;
        private FlattenCombo combo;
        private System.Windows.Forms.Button btn_RemoveThis;
    }
}
