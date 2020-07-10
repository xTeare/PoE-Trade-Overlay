namespace PoE_Trade_Overlay.Controls
{
    partial class ExpandCollapse
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
            this.panel_dropZone = new System.Windows.Forms.Panel();
            this.pb_header = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.pb_toggle = new System.Windows.Forms.PictureBox();
            this.pb_accent1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_header)).BeginInit();
            this.pb_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_toggle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_accent1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_dropZone
            // 
            this.panel_dropZone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_dropZone.BackColor = System.Drawing.Color.Transparent;
            this.panel_dropZone.Location = new System.Drawing.Point(3, 26);
            this.panel_dropZone.MinimumSize = new System.Drawing.Size(20, 20);
            this.panel_dropZone.Name = "panel_dropZone";
            this.panel_dropZone.Size = new System.Drawing.Size(441, 185);
            this.panel_dropZone.TabIndex = 0;
            // 
            // pb_header
            // 
            this.pb_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pb_header.Controls.Add(this.title);
            this.pb_header.Controls.Add(this.pb_toggle);
            this.pb_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_header.Location = new System.Drawing.Point(0, 0);
            this.pb_header.Name = "pb_header";
            this.pb_header.Size = new System.Drawing.Size(447, 20);
            this.pb_header.TabIndex = 1;
            this.pb_header.TabStop = false;
            this.pb_header.Click += new System.EventHandler(this.TogglePanel);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Consolas", 10F);
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.title.Location = new System.Drawing.Point(20, 2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(56, 17);
            this.title.TabIndex = 3;
            this.title.Text = "Header";
            this.title.Click += new System.EventHandler(this.TogglePanel);
            // 
            // pb_toggle
            // 
            this.pb_toggle.BackColor = System.Drawing.Color.Transparent;
            this.pb_toggle.Image = global::PoE_Trade_Overlay.Properties.Resources.chaos;
            this.pb_toggle.Location = new System.Drawing.Point(2, 2);
            this.pb_toggle.Name = "pb_toggle";
            this.pb_toggle.Size = new System.Drawing.Size(16, 16);
            this.pb_toggle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_toggle.TabIndex = 2;
            this.pb_toggle.TabStop = false;
            this.pb_toggle.Click += new System.EventHandler(this.TogglePanel);
            // 
            // pb_accent1
            // 
            this.pb_accent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.pb_accent1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_accent1.Location = new System.Drawing.Point(0, 20);
            this.pb_accent1.Name = "pb_accent1";
            this.pb_accent1.Size = new System.Drawing.Size(447, 1);
            this.pb_accent1.TabIndex = 26;
            this.pb_accent1.TabStop = false;
            // 
            // ExpandCollapse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.Controls.Add(this.pb_accent1);
            this.Controls.Add(this.pb_header);
            this.Controls.Add(this.panel_dropZone);
            this.Name = "ExpandCollapse";
            this.Size = new System.Drawing.Size(447, 215);
            ((System.ComponentModel.ISupportInitialize)(this.pb_header)).EndInit();
            this.pb_header.ResumeLayout(false);
            this.pb_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_toggle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_accent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_dropZone;
        private System.Windows.Forms.PictureBox pb_header;
        private System.Windows.Forms.PictureBox pb_toggle;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox pb_accent1;
    }
}
