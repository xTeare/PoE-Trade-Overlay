using PoE_Trade_Overlay.Queries;
using System.Windows.Forms;

namespace PoE_Trade_Overlay.Controls
{
    public partial class TabWithQuery : TabPage
    {
        public SearchResultManager srm;
        public string query;
        public string pseudos;
        public string header;
        public string modToSort;
        public bool sortDesc;

        public TabWithQuery()
        {
        }

        public FlowLayoutPanel GetFLP()
        {
            foreach (Control c in this.Controls)
                if (c.GetType() == typeof(FlowLayoutPanel))
                    return (FlowLayoutPanel)c;
            return null;
        }
    }
}