namespace PoE_Trade_Overlay
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel_Main = new System.Windows.Forms.Panel();
            this.settings = new System.Windows.Forms.PictureBox();
            this.search = new System.Windows.Forms.PictureBox();
            this.pb_drag = new System.Windows.Forms.PictureBox();
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_drag)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.Transparent;
            this.panel_Main.BackgroundImage = global::PoE_Trade_Overlay.Properties.Resources.Panel;
            this.panel_Main.Controls.Add(this.settings);
            this.panel_Main.Controls.Add(this.search);
            this.panel_Main.Controls.Add(this.pb_drag);
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(76, 28);
            this.panel_Main.TabIndex = 1;
            // 
            // settings
            // 
            this.settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settings.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.settings.Image = global::PoE_Trade_Overlay.Properties.Resources.Settings;
            this.settings.Location = new System.Drawing.Point(51, 0);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(26, 28);
            this.settings.TabIndex = 2;
            this.settings.TabStop = false;
            this.settings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.settings_MouseDown);
            // 
            // search
            // 
            this.search.Image = global::PoE_Trade_Overlay.Properties.Resources.search;
            this.search.Location = new System.Drawing.Point(25, 0);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(26, 28);
            this.search.TabIndex = 1;
            this.search.TabStop = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // pb_drag
            // 
            this.pb_drag.BackgroundImage = global::PoE_Trade_Overlay.Properties.Resources.move;
            this.pb_drag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_drag.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pb_drag.Location = new System.Drawing.Point(0, 0);
            this.pb_drag.Name = "pb_drag";
            this.pb_drag.Size = new System.Drawing.Size(25, 28);
            this.pb_drag.TabIndex = 0;
            this.pb_drag.TabStop = false;
            // 
            // tray
            // 
            this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
            this.tray.Text = "notifyIcon1";
            this.tray.Visible = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1940, 1100);
            this.Controls.Add(this.panel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Main";
            this.TopMost = true;
            this.panel_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_drag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.PictureBox pb_drag;
        private System.Windows.Forms.PictureBox search;
        private System.Windows.Forms.PictureBox settings;
        private System.Windows.Forms.NotifyIcon tray;
    }
}