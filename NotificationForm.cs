using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiptManager
{
    public partial class NotificationForm : Form
    {
        Control? _parent;
        public NotificationForm(Control parent)
        {
            InitializeComponent();
            NotificationText.Text = string.Empty;
            _parent = parent;
            ControlBox = false;
        }

        public void SetText(string text)
        {
            NotificationText.Text = text;
            CenterText();
        }

        private void CenterText()
        {
            NotificationText.Location = new Point(this.Width / 2 - NotificationText.Width /2, this.Height / 2 - NotificationText.Height /2);
        }

        public void ShowAndDisableParent()
        {
            _parent.Enabled = false;
            Show();
            TopMost = true;
            CenterToParent();
        }

        public void HideAndEnableParent()
        {
            if (InvokeRequired)
            {
                Invoke(HideAndEnableParent);
                return;
            }
            _parent.Enabled = true;
            TopMost = false;
            Hide();
        }

    }
}
