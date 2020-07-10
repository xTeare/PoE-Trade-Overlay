namespace PoE_Trade_Overlay.Controls
{
    partial class Filter_ModSearch
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
            this.tb_Mod = new System.Windows.Forms.TextBox();
            this.lb_Mods = new System.Windows.Forms.ListBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tb_max = new System.Windows.Forms.TextBox();
            this.tb_min = new System.Windows.Forms.TextBox();
            this.tb_weight = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Mod
            // 
            this.tb_Mod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.tb_Mod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Mod.Font = new System.Drawing.Font("Consolas", 12F);
            this.tb_Mod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.tb_Mod.Location = new System.Drawing.Point(3, 2);
            this.tb_Mod.Name = "tb_Mod";
            this.tb_Mod.Size = new System.Drawing.Size(442, 19);
            this.tb_Mod.TabIndex = 30;
            this.tb_Mod.TextChanged += new System.EventHandler(this.Tb_Mod_TextChanged);
            this.tb_Mod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tb_Mod_KeyDown);
            // 
            // lb_Mods
            // 
            this.lb_Mods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.lb_Mods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_Mods.Font = new System.Drawing.Font("Consolas", 10F);
            this.lb_Mods.ForeColor = System.Drawing.Color.White;
            this.lb_Mods.FormattingEnabled = true;
            this.lb_Mods.ItemHeight = 15;
            this.lb_Mods.Location = new System.Drawing.Point(3, 3);
            this.lb_Mods.Name = "lb_Mods";
            this.lb_Mods.Size = new System.Drawing.Size(569, 15);
            this.lb_Mods.TabIndex = 31;
            this.lb_Mods.Visible = false;
            this.lb_Mods.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lb_Mods_MouseDown);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(22)))));
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Consolas", 9F);
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.btn_Close.Location = new System.Drawing.Point(553, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(19, 19);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "X";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // tb_max
            // 
            this.tb_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.tb_max.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_max.Font = new System.Drawing.Font("Consolas", 12F);
            this.tb_max.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.tb_max.Location = new System.Drawing.Point(502, 2);
            this.tb_max.Name = "tb_max";
            this.tb_max.Size = new System.Drawing.Size(45, 19);
            this.tb_max.TabIndex = 3;
            this.tb_max.Text = "max";
            this.tb_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_max.TextChanged += new System.EventHandler(this.Tb_max_TextChanged);
            // 
            // tb_min
            // 
            this.tb_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.tb_min.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_min.Font = new System.Drawing.Font("Consolas", 12F);
            this.tb_min.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.tb_min.Location = new System.Drawing.Point(451, 2);
            this.tb_min.Name = "tb_min";
            this.tb_min.Size = new System.Drawing.Size(45, 19);
            this.tb_min.TabIndex = 2;
            this.tb_min.Text = "min";
            this.tb_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_min.TextChanged += new System.EventHandler(this.Tb_min_TextChanged);
            // 
            // tb_weight
            // 
            this.tb_weight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_weight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.tb_weight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_weight.Font = new System.Drawing.Font("Consolas", 12F);
            this.tb_weight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.tb_weight.Location = new System.Drawing.Point(383, 2);
            this.tb_weight.Name = "tb_weight";
            this.tb_weight.Size = new System.Drawing.Size(62, 19);
            this.tb_weight.TabIndex = 36;
            this.tb_weight.Text = "weight";
            this.tb_weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_weight.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.pictureBox1.Location = new System.Drawing.Point(3, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 1);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // Filter_ModSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tb_weight);
            this.Controls.Add(this.tb_max);
            this.Controls.Add(this.tb_min);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tb_Mod);
            this.Controls.Add(this.lb_Mods);
            this.MinimumSize = new System.Drawing.Size(575, 25);
            this.Name = "Filter_ModSearch";
            this.Size = new System.Drawing.Size(575, 25);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Mod;
        private System.Windows.Forms.ListBox lb_Mods;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TextBox tb_max;
        private System.Windows.Forms.TextBox tb_min;
        private System.Windows.Forms.TextBox tb_weight;
    }
}
