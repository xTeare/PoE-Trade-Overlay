using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PoE_Trade_Overlay.Controls
{
    [Designer(typeof(PoE_Trade_Overlay.Controls.CollapsePanelDesigner))]
    public partial class ExpandCollapse : UserControl
    {
        [Description("Size while expanded"), Category("Data")]
        public Size SizeExpanded
        {
            get { return sizeExpanded; }
            set { sizeExpanded = value; }
        }

        [Description("Header Text"), Category("Data")]
        public string Header
        {
            get { return title.Text; }
            set { title.Text = value; }
        }

        [Description("Header Height on collapse"), Category("Data")]
        public int HeaderHeight
        {
            get { return headerHeight; }
            set { headerHeight = value; }
        }

        public int headerHeight = 20;
        public bool isExpanded = true;
        public Size sizeExpanded;
        public Color color_active;
        public Color color_inactive;

        public Color color_header_active;
        public Color color_header_inactive;

        public Image image_active;
        public Image image_inactive;

        public Color ForeColor_Active;
        public Color ForeColor_Inactive;
        private Color backColor_Active;

        public Color BackColor_HeaderActive
        {
            get { return backColor_Active; }
            set
            {
                backColor_Active = value;
                RefreshControls();
            }
        }

        public Color BackColor_HeaderInactive { get; set; }
        public Image Image_Active;
        public Image Image_Inactive;

        public ExpandCollapse()
        {
            this.SetStyle(ControlStyles.CacheText, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            RefreshControls();
            this.SizeChanged += ExpandCollapse_SizeChanged;
        }

        private void ExpandCollapse_SizeChanged(object sender, EventArgs e)
        {
            if (DesignMode)
                sizeExpanded = this.Size;
        }

        // define a property called "DropZone"
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel DropZone
        {
            get { return panel_dropZone; }
        }

        public void TogglePanel(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            RefreshControls();
        }

        public void AddControl(Control c)
        {
            DropZone.Controls.Add(c);
        }

        public void RefreshControls()
        {
            if (Image_Active == null)
                Image_Active = Properties.Resources.chaos;
            if (Image_Inactive == null)
                Image_Inactive = Properties.Resources.chaos_bw;

            this.Size = (isExpanded) ? sizeExpanded : new Size(Size.Width, headerHeight);

            this.pb_toggle.Image = (isExpanded) ? Image_Active : Image_Inactive;

            this.title.ForeColor = (isExpanded) ? ForeColor_Active : ForeColor_Inactive;

            this.pb_header.BackColor = (isExpanded) ? BackColor_HeaderActive : BackColor_HeaderInactive;

            title.BackColor = Color.Transparent;
        }
    }

    public class CollapsePanelDesigner : ParentControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (this.Control is ExpandCollapse)
            {
                this.EnableDesignMode(((ExpandCollapse)this.Control).DropZone, "DropZone");
            }
        }
    }
}