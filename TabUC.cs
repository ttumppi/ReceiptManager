using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuittisovellus
{
    public class TabUC : UserControl
    {
        public TabUC(int tabHeight)
        {
            setUCSize(tabHeight);
        }
        public TabUC() { }

        protected void setUCSize(int tabHeight)
        {
            this.Location = new Point(0, tabHeight);
            this.Size = new Size(Settings.Instance.UCSize.Width, Settings.Instance.UCSize.Height);

        }
    }
}
