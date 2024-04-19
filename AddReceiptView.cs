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
        Info? _currentEditObject;
        Action<Info>? _onEdit;

        public AddReceiptView(int tabHeight, Control parent, Mode mode)
        {
            InitializeComponent();

            Read();

            setUCSize(tabHeight);
            _appConnected = false;
            CreateAndSetImageViewer(tabHeight);

            _notification = new NotificationForm(parent);
            _searching = false;

            SetButtons(mode);
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

            Info receipt_object = new Info(PurchaseNameInput.Text, ExpirationDateInput.Text, // create object
               PurchaseDateInput.Text, CostInput.Text, _imgPath, _uniqueIDGenerator.GenerateUniqueID());

            _onSave(this, receipt_object);

            _imgPath = string.Empty;
            PurchaseNameInput.Text = String.Empty;
            ExpirationDateInput.Text = String.Empty;
            PurchaseDateInput.Text = String.Empty;
            CostInput.Text = String.Empty;

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

        public void RegisterForEdit(Action<Info> action)
        {
            _onEdit = action;
        }

        private bool isDateValid()
        {
            if (ExpirationDateInput.Text == String.Empty)
            {
                DialogResult res = MessageBox.Show("Expiration date is in wrong format. Must be in /dd/mm/yyyy/", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }

            }
            if (!DateTime.TryParse(ExpirationDateInput.Text, out DateTime _temp))
            {
                DialogResult res = MessageBox.Show("Expiration date is in wrong format. Must be in /dd/mm/yyyy/", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }

            if (PurchaseDateInput.Text == String.Empty)
            {
                DialogResult res = MessageBox.Show("Purchase date is in wrong format. Must be in /dd/mm/yyyy/", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }
            if (!DateTime.TryParse(PurchaseDateInput.Text, out DateTime _temp1))
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
            if (CostInput.Text == String.Empty)
            {
                DialogResult res = MessageBox.Show("Cost is empty", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }

            CostInput.Text = StringFunctions.RemoveNonNumbersRetainDot(CostInput.Text);

            if (CostInput.Text.Contains(','))
            {
                DialogResult res = MessageBox.Show("Cost can only contain '.'", "Wrong Format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }
            if (CostInput.Text.Split('.').Length > 2)
            {
                DialogResult res = MessageBox.Show("The maximum amount of '.' cost can have is 1", "Wrong Format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }
            if (!CostInput.Text.Any(char.IsDigit))
            {
                DialogResult res = MessageBox.Show("Cost must have numbers", "Wrong format", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    return false;
                }
            }
            if (CostInput.Text[CostInput.Text.Length - 1] == '.')
            {
                while (CostInput.Text[CostInput.Text.Length - 1] == '.')
                {
                    CostInput.Text = CostInput.Text.Remove(CostInput.Text.Length - 1);
                }

            }


            return true;
        }

        private bool isNameValid()
        {
            if (PurchaseNameInput.Text == String.Empty)
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
                else
                {
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClearFields();
            _currentEditObject = null;
            
        }

        public void EnableBackButton()
        {
            BackButton.Enabled = true;
            BackButton.Visible = true;
        }

        public void DisableBackButton()
        {
            BackButton.Enabled = false;
            BackButton.Visible = false;
        }

        public void FillWithInfoObject(Info info)
        {
            PurchaseNameInput.Text = info.Name;
            ExpirationDateInput.Text = info.ExpirationDate;
            PurchaseDateInput.Text = info.PurchaseDate;
            CostInput.Text = info.Cost;
            _currentEditObject = info;
        }

        private void ClearFields()
        {
            PurchaseNameInput.Text = string.Empty;
            ExpirationDateInput.Text = string.Empty;
            PurchaseDateInput.Text = string.Empty;
            CostInput.Text = string.Empty;

        }

        private void EditButton_Click(object sender, EventArgs e)
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

            if (_currentEditObject is null)
            {
                return;
            }

            if (_imgPath == string.Empty)
            {
                _currentEditObject = new Info(PurchaseNameInput.Text, ExpirationDateInput.Text, PurchaseDateInput.Text,
                    CostInput.Text, _currentEditObject.ImgPath, _currentEditObject.ID);
            }
            else
            {
                _currentEditObject = new Info(PurchaseNameInput.Text, ExpirationDateInput.Text, PurchaseDateInput.Text,
                    CostInput.Text, _imgPath, _currentEditObject.ID);
            }
            if (_onEdit is null)
            {
                return;
            }
            _onEdit.Invoke(_currentEditObject);
        }

        private void EnableEditMode()
        {
            AddButton.Enabled = false;
            AddButton.Visible = false;
            EditButton.Enabled = true;
            EditButton.Visible = true;
        }

        private void EnableAddMode()
        {
            AddButton.Enabled = true;
            AddButton.Visible = true;
            EditButton.Enabled = false;
            EditButton.Visible = false;
        }

        private void SetButtons(Mode mode)
        {
            switch (mode)
            {
                case Mode.None:
                    goto case Mode.Add;
                case Mode.Add:
                    EnableAddMode();
                    break;
                case Mode.Edit:
                    EnableEditMode();
                    break;
            }
        }



        public enum Mode
        {
            None = 0,
            Add = 1,
            Edit = 2,
        }
    }
}
