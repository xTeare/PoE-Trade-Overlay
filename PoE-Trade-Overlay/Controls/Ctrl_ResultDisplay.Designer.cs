namespace PoE_Trade_Overlay.Controls
{
    partial class Ctrl_ResultDisplay
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
            this.flp_item = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_wiki = new System.Windows.Forms.Button();
            this.pb_itemArt = new PoE_Trade_Overlay.Controls.BetterPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_itemArt)).BeginInit();
            this.SuspendLayout();
            // 
            // flp_item
            // 
            this.flp_item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_item.AutoSize = true;
            this.flp_item.BackColor = System.Drawing.Color.Transparent;
            this.flp_item.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_item.Location = new System.Drawing.Point(106, 3);
            this.flp_item.Name = "flp_item";
            this.flp_item.Size = new System.Drawing.Size(501, 74);
            this.flp_item.TabIndex = 1;
            // 
            // btn_wiki
            // 
            this.btn_wiki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_wiki.BackColor = System.Drawing.Color.Transparent;
            this.btn_wiki.FlatAppearance.BorderSize = 0;
            this.btn_wiki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_wiki.Image = global::PoE_Trade_Overlay.Properties.Resources.wiki;
            this.btn_wiki.Location = new System.Drawing.Point(0, 0);
            this.btn_wiki.Name = "btn_wiki";
            this.btn_wiki.Size = new System.Drawing.Size(23, 23);
            this.btn_wiki.TabIndex = 5;
            this.btn_wiki.UseVisualStyleBackColor = false;
            this.btn_wiki.Visible = false;
            // 
            // pb_itemArt
            // 
            this.pb_itemArt.Location = new System.Drawing.Point(3, 2);
            this.pb_itemArt.Name = "pb_itemArt";
            this.pb_itemArt.Size = new System.Drawing.Size(94, 75);
            this.pb_itemArt.TabIndex = 6;
            this.pb_itemArt.TabStop = false;
            // 
            // Ctrl_ResultDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(27)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.pb_itemArt);
            this.Controls.Add(this.btn_wiki);
            this.Controls.Add(this.flp_item);
            this.MaximumSize = new System.Drawing.Size(615, 0);
            this.Name = "Ctrl_ResultDisplay";
            this.Size = new System.Drawing.Size(615, 80);
            this.Load += new System.EventHandler(this.Ctrl_ResultDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_itemArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flp_item;
        private BetterPictureBox pb_itemArt;
        private System.Windows.Forms.Button btn_wiki;
    }
}
