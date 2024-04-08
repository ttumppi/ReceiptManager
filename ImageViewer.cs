using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuittisovellus
{
    public partial class ImageViewer : TabUC
    {
        public ImageViewer(int tabHeight)
        {
            InitializeComponent();
            setUCSize(tabHeight);
        }

       

        public void AddImage(Image img)
        {
            if (PictureBox.InvokeRequired)
            {
                
                PictureBox.Invoke(new Action(() => AddImage(img)));
                return;
            }
            
            PictureBox.Image = img;
        }
    }
}
