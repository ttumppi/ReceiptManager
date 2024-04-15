using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuittisovellus
{
    public partial class ImageViewer : TabUC
    {
        Action<DialogResult, Image>? _Dialoglistener;
        Action? _imageReceivedListener;

        public ImageViewer(int tabHeight)
        {
            InitializeComponent();
            setUCSize(tabHeight);
        }



        public void AddImage(Image img, byte? orientation)
        {
            if (_imageReceivedListener is not null)
            {
                _imageReceivedListener.Invoke();
            }
            
            
            if (PictureBox.InvokeRequired)
            {

                PictureBox.Invoke(new Action(() => AddImage(img, orientation)));
                return;
            }

            new ImageFunctions(img, orientation).FlipImageToCorrectOrientation();


            if (img.Size.Width + img.Size.Height > PictureBox.Size.Width + PictureBox.Size.Height)
            {
                PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PictureBox.SizeMode = PictureBoxSizeMode.Normal;
            }
            PictureBox.Image = img;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (_Dialoglistener is not null)
            {
                _Dialoglistener.Invoke(DialogResult.OK, PictureBox.Image);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (_Dialoglistener is not null)
            {
                _Dialoglistener.Invoke(DialogResult.Cancel, PictureBox.Image);
            }
        }

        public void RegisterConfirmationListener(Action<DialogResult, Image> listener)
        {
            _Dialoglistener = listener;
        }

        public void EnableConfirmationControls()
        {
            ConfirmationControlsPanel.Enabled = true;
            ConfirmationControlsPanel.Visible = true;
        }

        public void DisableConfirmationControls()
        {
            ConfirmationControlsPanel.Enabled = false;
            ConfirmationControlsPanel.Visible = false;
        }

        public void RegisterImageReceivedListener(Action listener)
        {
            _imageReceivedListener = listener;
        }
    }

    public class ImageFunctions
    {
        Image _img;
        private Dictionary<Orientation, RotateFlipType> _rotationActions;
        byte? _orientation;
            

        public ImageFunctions(Image img, byte? orientation)
        {
            _img = img;
            _rotationActions = new Dictionary<Orientation, RotateFlipType> { { Orientation.FlipX, RotateFlipType.RotateNoneFlipX },
                { Orientation.FlipXY, RotateFlipType.RotateNoneFlipXY},
                {Orientation.FlipY, RotateFlipType.RotateNoneFlipY },
                {Orientation.Rotate90FlipX, RotateFlipType.Rotate90FlipX },
                {Orientation.Rotate90, RotateFlipType.Rotate90FlipNone },
                {Orientation.Rotate90FlipY, RotateFlipType.Rotate90FlipY },
                {Orientation.Rotate90FlipXY, RotateFlipType.Rotate90FlipXY },
            };
            _orientation = orientation;
        }
        public void FlipImageToCorrectOrientation()
        {
            

            if (_orientation is null)
            {
                return;
            }

            

            if (_rotationActions.ContainsKey((Orientation)_orientation)){
                _img.RotateFlip(_rotationActions[(Orientation)_orientation]);
            }
            return;




        }

        private PropertyItem? GetPropertyForRotation()
        {
            PropertyItem? orientationProperty = null;
            foreach (PropertyItem item in _img.PropertyItems)
            {
                if (item.Id == 0x0112)
                {
                    orientationProperty = item;
                }
            }
            return orientationProperty;
        }

        private enum Orientation : byte
        {
            None = 1,
            FlipX = 2,
            FlipXY = 3,
            FlipY = 4,
            Rotate90FlipX = 5,
            Rotate90 = 6,
            Rotate90FlipY = 7,
            Rotate90FlipXY = 8,
        }
    }
}
