namespace PoE_Trade_Overlay
{
    partial class Form_Settings
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
            this.button1 = new System.Windows.Forms.Button();
            this.help_Discord = new System.Windows.Forms.PictureBox();
            this.help_PiC = new System.Windows.Forms.PictureBox();
            this.help_Sockets = new System.Windows.Forms.PictureBox();
            this.help_Afk = new System.Windows.Forms.PictureBox();
            this.help_Legacy = new System.Windows.Forms.PictureBox();
            this.help_Render = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_League = new System.Windows.Forms.Label();
            this.fcb_leagues = new PoE_Trade_Overlay.Controls.FlattenCombo();
            this.t_PiC = new PoE_Trade_Overlay.Controls.Toggle();
            this.t_Legacy = new PoE_Trade_Overlay.Controls.Toggle();
            this.t_Afk = new PoE_Trade_Overlay.Controls.Toggle();
            this.t_Render = new PoE_Trade_Overlay.Controls.Toggle();
            this.t_Sockets = new PoE_Trade_Overlay.Controls.Toggle();
            this.t_Discord = new PoE_Trade_Overlay.Controls.Toggle();
            this.pb_accent1 = new System.Windows.Forms.PictureBox();
            this.pb_accent2 = new System.Windows.Forms.PictureBox();
            this.help_Statistics = new System.Windows.Forms.PictureBox();
            this.t_Statistics = new PoE_Trade_Overlay.Controls.Toggle();
            ((System.ComponentModel.ISupportInitialize)(this.help_Discord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_PiC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Sockets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Afk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Legacy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Render)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_accent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_accent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Statistics)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(22)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.button1.Location = new System.Drawing.Point(0, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(351, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK !";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Ok);
            // 
            // help_Discord
            // 
            this.help_Discord.Image = global::PoE_Trade_Overlay.Properties.Resources._72_722963_circular_question_mark_button_question_mark_icon_white;
            this.help_Discord.Location = new System.Drawing.Point(315, 27);
            this.help_Discord.Name = "help_Discord";
            this.help_Discord.Size = new System.Drawing.Size(23, 23);
            this.help_Discord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help_Discord.TabIndex = 8;
            this.help_Discord.TabStop = false;
            // 
            // help_PiC
            // 
            this.help_PiC.Image = global::PoE_Trade_Overlay.Properties.Resources._72_722963_circular_question_mark_button_question_mark_icon_white;
            this.help_PiC.Location = new System.Drawing.Point(315, 62);
            this.help_PiC.Name = "help_PiC";
            this.help_PiC.Size = new System.Drawing.Size(23, 23);
            this.help_PiC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help_PiC.TabIndex = 9;
            this.help_PiC.TabStop = false;
            // 
            // help_Sockets
            // 
            this.help_Sockets.Image = global::PoE_Trade_Overlay.Properties.Resources._72_722963_circular_question_mark_button_question_mark_icon_white;
            this.help_Sockets.Location = new System.Drawing.Point(315, 97);
            this.help_Sockets.Name = "help_Sockets";
            this.help_Sockets.Size = new System.Drawing.Size(23, 23);
            this.help_Sockets.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help_Sockets.TabIndex = 10;
            this.help_Sockets.TabStop = false;
            // 
            // help_Afk
            // 
            this.help_Afk.Image = global::PoE_Trade_Overlay.Properties.Resources._72_722963_circular_question_mark_button_question_mark_icon_white;
            this.help_Afk.Location = new System.Drawing.Point(315, 132);
            this.help_Afk.Name = "help_Afk";
            this.help_Afk.Size = new System.Drawing.Size(23, 23);
            this.help_Afk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help_Afk.TabIndex = 11;
            this.help_Afk.TabStop = false;
            // 
            // help_Legacy
            // 
            this.help_Legacy.Image = global::PoE_Trade_Overlay.Properties.Resources._72_722963_circular_question_mark_button_question_mark_icon_white;
            this.help_Legacy.Location = new System.Drawing.Point(315, 167);
            this.help_Legacy.Name = "help_Legacy";
            this.help_Legacy.Size = new System.Drawing.Size(23, 23);
            this.help_Legacy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help_Legacy.TabIndex = 12;
            this.help_Legacy.TabStop = false;
            // 
            // help_Render
            // 
            this.help_Render.Image = global::PoE_Trade_Overlay.Properties.Resources._72_722963_circular_question_mark_button_question_mark_icon_white;
            this.help_Render.Location = new System.Drawing.Point(315, 202);
            this.help_Render.Name = "help_Render";
            this.help_Render.Size = new System.Drawing.Size(23, 23);
            this.help_Render.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help_Render.TabIndex = 13;
            this.help_Render.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_League
            // 
            this.lbl_League.AutoSize = true;
            this.lbl_League.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.lbl_League.Location = new System.Drawing.Point(10, 270);
            this.lbl_League.Name = "lbl_League";
            this.lbl_League.Size = new System.Drawing.Size(43, 13);
            this.lbl_League.TabIndex = 22;
            this.lbl_League.Text = "League";
            // 
            // fcb_leagues
            // 
            this.fcb_leagues.Arrow_Active = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.fcb_leagues.Arrow_Inactive = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.fcb_leagues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.fcb_leagues.BackColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(42)))));
            this.fcb_leagues.BackColorButton = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(32)))));
            this.fcb_leagues.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.fcb_leagues.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.fcb_leagues.Data = null;
            this.fcb_leagues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fcb_leagues.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.fcb_leagues.ForeColorDrop = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.fcb_leagues.FormattingEnabled = true;
            this.fcb_leagues.Location = new System.Drawing.Point(189, 267);
            this.fcb_leagues.Name = "fcb_leagues";
            this.fcb_leagues.Size = new System.Drawing.Size(150, 21);
            this.fcb_leagues.TabIndex = 21;
            // 
            // t_PiC
            // 
            this.t_PiC.Bar_Off = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.t_PiC.Bar_On = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.t_PiC.BarSize = new System.Drawing.Size(40, 10);
            this.t_PiC.Border_Off = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.t_PiC.Border_On = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.t_PiC.BorderRadius = 5;
            this.t_PiC.Caption = "Enable Price in Chaos conversion";
            this.t_PiC.ColorMode = PoE_Trade_Overlay.Controls.ColorMode.Follow;
            this.t_PiC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.t_PiC.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.t_PiC.KnobImage = null;
            this.t_PiC.KnobImageOn = null;
            this.t_PiC.KnobSize = new System.Drawing.Size(20, 20);
            this.t_PiC.KnobStyle = PoE_Trade_Overlay.Controls.KnobStyle.Circle;
            this.t_PiC.Location = new System.Drawing.Point(10, 59);
            this.t_PiC.Name = "t_PiC";
            this.t_PiC.On = false;
            this.t_PiC.Size = new System.Drawing.Size(299, 29);
            this.t_PiC.Spacing = 80;
            this.t_PiC.TabIndex = 7;
            this.t_PiC.TextIsLeft = true;
            this.t_PiC.ToggleSpeed = 5;
            // 
            // t_Legacy
            // 
            this.t_Legacy.Bar_Off = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.t_Legacy.Bar_On = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.t_Legacy.BarSize = new System.Drawing.Size(40, 10);
            this.t_Legacy.Border_Off = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.t_Legacy.Border_On = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.t_Legacy.BorderRadius = 5;
            this.t_Legacy.Caption = "Hide Legacy Maps";
            this.t_Legacy.ColorMode = PoE_Trade_Overlay.Controls.ColorMode.Follow;
            this.t_Legacy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.t_Legacy.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.t_Legacy.KnobImage = null;
            this.t_Legacy.KnobImageOn = null;
            this.t_Legacy.KnobSize = new System.Drawing.Size(20, 20);
            this.t_Legacy.KnobStyle = PoE_Trade_Overlay.Controls.KnobStyle.Circle;
            this.t_Legacy.Location = new System.Drawing.Point(10, 164);
            this.t_Legacy.Name = "t_Legacy";
            this.t_Legacy.On = false;
            this.t_Legacy.Size = new System.Drawing.Size(299, 29);
            this.t_Legacy.Spacing = 150;
            this.t_Legacy.TabIndex = 5;
            this.t_Legacy.TextIsLeft = true;
            this.t_Legacy.ToggleSpeed = 5;
            // 
            // t_Afk
            // 
            this.t_Afk.Bar_Off = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.t_Afk.Bar_On = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.t_Afk.BarSize = new System.Drawing.Size(40, 10);
            this.t_Afk.Border_Off = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.t_Afk.Border_On = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.t_Afk.BorderRadius = 5;
            this.t_Afk.Caption = "Hide AFK Sellers";
            this.t_Afk.ColorMode = PoE_Trade_Overlay.Controls.ColorMode.Follow;
            this.t_Afk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.t_Afk.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.t_Afk.KnobImage = null;
            this.t_Afk.KnobImageOn = null;
            this.t_Afk.KnobSize = new System.Drawing.Size(20, 20);
            this.t_Afk.KnobStyle = PoE_Trade_Overlay.Controls.KnobStyle.Circle;
            this.t_Afk.Location = new System.Drawing.Point(10, 129);
            this.t_Afk.Name = "t_Afk";
            this.t_Afk.On = false;
            this.t_Afk.Size = new System.Drawing.Size(299, 29);
            this.t_Afk.Spacing = 160;
            this.t_Afk.TabIndex = 4;
            this.t_Afk.TextIsLeft = true;
            this.t_Afk.ToggleSpeed = 5;
            // 
            // t_Render
            // 
            this.t_Render.Bar_Off = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.t_Render.Bar_On = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.t_Render.BarSize = new System.Drawing.Size(40, 10);
            this.t_Render.Border_Off = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.t_Render.Border_On = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.t_Render.BorderRadius = 5;
            this.t_Render.Caption = "Only render when PoE is running";
            this.t_Render.ColorMode = PoE_Trade_Overlay.Controls.ColorMode.Follow;
            this.t_Render.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.t_Render.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.t_Render.KnobImage = null;
            this.t_Render.KnobImageOn = null;
            this.t_Render.KnobSize = new System.Drawing.Size(20, 20);
            this.t_Render.KnobStyle = PoE_Trade_Overlay.Controls.KnobStyle.Circle;
            this.t_Render.Location = new System.Drawing.Point(10, 199);
            this.t_Render.Name = "t_Render";
            this.t_Render.On = false;
            this.t_Render.Size = new System.Drawing.Size(299, 29);
            this.t_Render.Spacing = 85;
            this.t_Render.TabIndex = 3;
            this.t_Render.TextIsLeft = true;
            this.t_Render.ToggleSpeed = 5;
            // 
            // t_Sockets
            // 
            this.t_Sockets.Bar_Off = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.t_Sockets.Bar_On = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.t_Sockets.BarSize = new System.Drawing.Size(40, 10);
            this.t_Sockets.Border_Off = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.t_Sockets.Border_On = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.t_Sockets.BorderRadius = 5;
            this.t_Sockets.Caption = "Hide Sockets on Hover";
            this.t_Sockets.ColorMode = PoE_Trade_Overlay.Controls.ColorMode.Follow;
            this.t_Sockets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.t_Sockets.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.t_Sockets.KnobImage = null;
            this.t_Sockets.KnobImageOn = null;
            this.t_Sockets.KnobSize = new System.Drawing.Size(20, 20);
            this.t_Sockets.KnobStyle = PoE_Trade_Overlay.Controls.KnobStyle.Circle;
            this.t_Sockets.Location = new System.Drawing.Point(10, 94);
            this.t_Sockets.Name = "t_Sockets";
            this.t_Sockets.On = false;
            this.t_Sockets.Size = new System.Drawing.Size(299, 29);
            this.t_Sockets.Spacing = 128;
            this.t_Sockets.TabIndex = 2;
            this.t_Sockets.TextIsLeft = true;
            this.t_Sockets.ToggleSpeed = 5;
            // 
            // t_Discord
            // 
            this.t_Discord.Bar_Off = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.t_Discord.Bar_On = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.t_Discord.BarSize = new System.Drawing.Size(40, 10);
            this.t_Discord.Border_Off = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.t_Discord.Border_On = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.t_Discord.BorderRadius = 5;
            this.t_Discord.Caption = "Enable Discord Rich Presence";
            this.t_Discord.ColorMode = PoE_Trade_Overlay.Controls.ColorMode.Follow;
            this.t_Discord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.t_Discord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.t_Discord.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.t_Discord.KnobImage = null;
            this.t_Discord.KnobImageOn = null;
            this.t_Discord.KnobSize = new System.Drawing.Size(20, 20);
            this.t_Discord.KnobStyle = PoE_Trade_Overlay.Controls.KnobStyle.Circle;
            this.t_Discord.Location = new System.Drawing.Point(10, 24);
            this.t_Discord.Name = "t_Discord";
            this.t_Discord.On = false;
            this.t_Discord.Size = new System.Drawing.Size(299, 29);
            this.t_Discord.Spacing = 94;
            this.t_Discord.TabIndex = 1;
            this.t_Discord.TextIsLeft = true;
            this.t_Discord.ToggleSpeed = 5;
            // 
            // pb_accent1
            // 
            this.pb_accent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.pb_accent1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_accent1.Location = new System.Drawing.Point(0, 20);
            this.pb_accent1.Name = "pb_accent1";
            this.pb_accent1.Size = new System.Drawing.Size(351, 1);
            this.pb_accent1.TabIndex = 23;
            this.pb_accent1.TabStop = false;
            // 
            // pb_accent2
            // 
            this.pb_accent2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_accent2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.pb_accent2.Location = new System.Drawing.Point(0, 297);
            this.pb_accent2.Name = "pb_accent2";
            this.pb_accent2.Size = new System.Drawing.Size(350, 1);
            this.pb_accent2.TabIndex = 24;
            this.pb_accent2.TabStop = false;
            // 
            // help_Statistics
            // 
            this.help_Statistics.Image = global::PoE_Trade_Overlay.Properties.Resources._72_722963_circular_question_mark_button_question_mark_icon_white;
            this.help_Statistics.Location = new System.Drawing.Point(315, 237);
            this.help_Statistics.Name = "help_Statistics";
            this.help_Statistics.Size = new System.Drawing.Size(23, 23);
            this.help_Statistics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.help_Statistics.TabIndex = 26;
            this.help_Statistics.TabStop = false;
            // 
            // t_Statistics
            // 
            this.t_Statistics.Bar_Off = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            this.t_Statistics.Bar_On = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(36)))));
            this.t_Statistics.BarSize = new System.Drawing.Size(40, 10);
            this.t_Statistics.Border_Off = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.t_Statistics.Border_On = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.t_Statistics.BorderRadius = 5;
            this.t_Statistics.Caption = "Send anonymous search statistics";
            this.t_Statistics.ColorMode = PoE_Trade_Overlay.Controls.ColorMode.Follow;
            this.t_Statistics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.t_Statistics.KnobColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(56)))), ((int)(((byte)(6)))));
            this.t_Statistics.KnobImage = null;
            this.t_Statistics.KnobImageOn = null;
            this.t_Statistics.KnobSize = new System.Drawing.Size(20, 20);
            this.t_Statistics.KnobStyle = PoE_Trade_Overlay.Controls.KnobStyle.Circle;
            this.t_Statistics.Location = new System.Drawing.Point(10, 234);
            this.t_Statistics.Name = "t_Statistics";
            this.t_Statistics.On = false;
            this.t_Statistics.Size = new System.Drawing.Size(305, 29);
            this.t_Statistics.Spacing = 85;
            this.t_Statistics.TabIndex = 25;
            this.t_Statistics.TextIsLeft = true;
            this.t_Statistics.ToggleSpeed = 5;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(24)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(351, 321);
            this.Controls.Add(this.help_Statistics);
            this.Controls.Add(this.t_Statistics);
            this.Controls.Add(this.pb_accent2);
            this.Controls.Add(this.pb_accent1);
            this.Controls.Add(this.lbl_League);
            this.Controls.Add(this.fcb_leagues);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.help_Render);
            this.Controls.Add(this.help_Legacy);
            this.Controls.Add(this.help_Afk);
            this.Controls.Add(this.help_Sockets);
            this.Controls.Add(this.help_PiC);
            this.Controls.Add(this.help_Discord);
            this.Controls.Add(this.t_PiC);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.t_Legacy);
            this.Controls.Add(this.t_Afk);
            this.Controls.Add(this.t_Render);
            this.Controls.Add(this.t_Sockets);
            this.Controls.Add(this.t_Discord);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Settings";
            ((System.ComponentModel.ISupportInitialize)(this.help_Discord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_PiC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Sockets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Afk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Legacy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Render)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_accent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_accent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.help_Statistics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Toggle t_Discord;
        private Controls.Toggle t_Sockets;
        private Controls.Toggle t_Render;
        private Controls.Toggle t_Afk;
        private Controls.Toggle t_Legacy;
        private System.Windows.Forms.Button button1;
        private Controls.Toggle t_PiC;
        private System.Windows.Forms.PictureBox help_Discord;
        private System.Windows.Forms.PictureBox help_PiC;
        private System.Windows.Forms.PictureBox help_Sockets;
        private System.Windows.Forms.PictureBox help_Afk;
        private System.Windows.Forms.PictureBox help_Legacy;
        private System.Windows.Forms.PictureBox help_Render;
        private System.Windows.Forms.Label label1;
        private Controls.FlattenCombo fcb_leagues;
        private System.Windows.Forms.Label lbl_League;
        private System.Windows.Forms.PictureBox pb_accent1;
        private System.Windows.Forms.PictureBox pb_accent2;
        private System.Windows.Forms.PictureBox help_Statistics;
        private Controls.Toggle t_Statistics;
    }
}