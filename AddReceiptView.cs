using ReceiptManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Kuittisovellus
{
    public partial class AddReceiptView : TabUC
    {
        private string _imgPath = string.Empty;
        private EventHandler<Info> _onSave;
        private UniqueIDGenerator _uniqueIDGenerator;
        volatile bool _appConnected;
        ImageViewer _imageViewer;
        Image? _sentImage;
        string? _sentImagePath;
        Action? _connectionRequestedListener;
        NotificationForm _notification;
        bool _searching;

        public AddReceiptView(int tabHeight, Control parent)
        {
            InitializeComponent();

            Read();

            setUCSize(tabHeight);
            _appConnected = false;
            CreateAndSetImageViewer(tabHeight);
            
            _notification = new NotificationForm(parent);
            _searching = false;
        }

        private void CreateAndSetImageViewer(int tabHeight)
        {
            _imageViewer = new ImageViewer(tabHeight);
            _imageViewer.RegisterConfirmationListener(OnImageViewerResult);
            _imageViewer.RegisterImageReceivedListener(ShowImageView);
            _imageViewer.EnableConfirmationControls();
            this.Controls.Add(_imageViewer);
            _imageViewer.BringToFront();
            _imageViewer.Hide();
            _imageViewer.Location = new Point(0, 0);
        }

        private void AddButton_Click(object sender, EventArgs e)      // save button
        {
            if (!isDateValid())
            {
                return;
            }
            if (!isCostValid())
            {
                return;
            }
            if (!isNameValid())
            {
                return;
            }

            SaveImageToFileIfExists();

            Info receipt_object = new Info(Purchase_input.Text, Expiration_date_input.Text, // create object
               Date_input.Text, StringFunctions.RemoveNonNumbers(Cost_input.Text), _imgPath, _uniqueIDGenerator.GenerateUniqueID());

            _onSave(this, receipt_object);

            _imgPath = string.Empty;
            Purchase_input.Text = String.Empty;
            Expiration_date_input.Text = String.Empty;
            Date_input.Text = String.Empty;
            Cost_input.Text = String.Empty;

        }

        private void SelectImageButton_Click(object sender, EventArgs e)  // opens file explorer and saves selected image path
        {

            using (OpenFileDialog file_explorer = new OpenFileDialog())
            {
                file_explorer.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (file_explorer.ShowDialog() == DialogResult.OK)
                {
                    _imgPath = file_explorer.FileName;

                }

            }
            _sentImage = null;
            _sentImagePath = null;
        }

        public void RegisterForSave(EventHandler<Info> toRegister)
        {
            _onSave += toRegister;
        }

        private bool isDateValid()
        {
            if (Expiration_date_input.Text == String.Empty)
            {
                DialogResult res = MessageBox.Show("Expiration date is in wrong format. Must be in /dd/mm/yyyy/", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }

            }
            if (!DateTime.TryParse(Expiration_date_input.Text, out DateTime _temp))
            {
                DialogResult res = MessageBox.Show("Expiration date is in wrong format. Must be in /dd/mm/yyyy/", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }

            if (Date_input.Text == String.Empty)
            {
                DialogResult res = MessageBox.Show("Purchase date is in wrong format. Must be in /dd/mm/yyyy/", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }
            if (!DateTime.TryParse(Date_input.Text, out DateTime _temp1))
            {
                DialogResult res = MessageBox.Show("Purchase date is in wrong format. Must be in /dd/mm/yyyy/", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        private bool isCostValid()
        {
            if (Cost_input.Text == String.Empty)
            {
                DialogResult res = MessageBox.Show("Cost is empty", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }

            if (Cost_input.Text.Contains(','))
            {
                DialogResult res = MessageBox.Show("Cost can only contain '.'", "Wrong Format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }
            if (Cost_input.Text.Split('.').Length > 2)
            {
                DialogResult res = MessageBox.Show("The maximum amount of '.' cost can have is 1", "Wrong Format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }

            return true;
        }

        private bool isNameValid()
        {
            if (Purchase_input.Text == String.Empty)
            {
                DialogResult res = MessageBox.Show("Purchase must have a name", "Wrong Format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        public void Write()
        {

            _uniqueIDGenerator.Write();
        }

        private void Read()
        {
            _uniqueIDGenerator = UniqueIDGenerator.Read();
        }

        private void SendImageWithAppButton_Click(object sender, EventArgs e)
        {
            if (_appConnected)
            {
                _searching = false;
                _notification.SetText("Waiting to receive image");
                _notification.ShowAndDisableParent();

            }
            else
            {
                if (_searching)
                {
                    MessageBox.Show("You have to connect the app before you can send an image");
                }
                else {
                    if (MessageBox.Show("No app connected, would you like to connect now?", "No connection",
                    MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        _searching = true;
                        _connectionRequestedListener.Invoke();
                    }
                }
                    
            }
        }

        public void RegisterOnConnectionRequestedListener(Action listener)
        {
            _connectionRequestedListener = listener;
        }

        public void OnAppConnectionChange(object? sender, ServerSocket.ConnectionChangedEventArgs args)
        {
            if (args.State == ServerSocket.ConnectionChangedEventArgs.ConnectionState.None)
            {
                return;
            }

            _appConnected = args.State.Equals(ServerSocket.ConnectionChangedEventArgs.ConnectionState.Connected);
        }

        public void OnImageViewerResult(DialogResult res, Image sentImage)
        {
            if (res == DialogResult.OK)
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        _sentImage = sentImage;
                        _sentImagePath = dialog.SelectedPath;
                    }
                }
            }
            if (_imageViewer.InvokeRequired)
            {
                _imageViewer.Invoke(_imageViewer.Hide);
                return;
            }
            _imageViewer.Hide();
        }

        private void SaveImageToFileIfExists()
        {
            if (_sentImage is null)
            {
                return;
            }

            string filePath = Path.Combine(_sentImagePath, CurrentTimeToFileName() + "." + ImageFormat.Jpeg);

            _sentImage.Save(filePath);


            _imgPath = filePath;

            _sentImage = null;
            _sentImagePath = null;
        }

        private string CurrentTimeToFileName()
        {
            return DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss");
        }
        public Action<Image, byte?> GetImageViewerOnImage()
        {
            return _imageViewer.AddImage;
        }

        public void ShowImageView()
        {
            _notification.HideAndEnableParent();
            if (_imageViewer.InvokeRequired)
            {
                _imageViewer.Invoke(_imageViewer.Show);
            }
        }

        
    }
}
