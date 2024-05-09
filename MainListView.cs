using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Xml.Serialization;

namespace ReceiptManager
{
    public partial class MainListView : TabUC
    {
        List<int> _columnWidths = new List<int>();


        private Dictionary<string, Info> _receiptItems = new Dictionary<string, Info>();

        private ListViewItem? _selectedItem;

        private ImageViewer _imageViewer;

        private AddReceiptView _editReceiptView;


        public Dictionary<string, Info> Receipts
        {
            get { return _receiptItems; }
            set { _receiptItems = value; }
        }

        private bool[] _sortOrder = new bool[] { false, false, false, false, false };

        public MainListView(int tabHeight, Control parent)
        {
            InitializeComponent();
            CreateColumns();
            SetControls();
            setUCSize(tabHeight);
            CreateAndSetImageViewer(tabHeight);
            CreateAndSetEditReceiptView(tabHeight, parent);
        }

        private void CreateAndSetImageViewer(int tabHeight)
        {
            _imageViewer = new ImageViewer(tabHeight);
            this.Controls.Add(_imageViewer);
            _imageViewer.BringToFront();
            _imageViewer.Hide();
            _imageViewer.EnableBackButton();
            _imageViewer.Location = new Point(0, 0);
        }

        private void CreateAndSetEditReceiptView(int tabHeight, Control parent)
        {
            _editReceiptView = new AddReceiptView(tabHeight, parent, AddReceiptView.Mode.Edit);
            _editReceiptView.RegisterForEdit(EditListView);
            this.Controls.Add(_editReceiptView);
            _editReceiptView.Hide();
            _editReceiptView.BringToFront();
            _editReceiptView.EnableBackButton();
            _editReceiptView.Location = new Point(0, 0);
            
        }

        public void LinkConnectionRequestedListenerToEditView(Action listener)
        {
            _editReceiptView.RegisterOnConnectionRequestedListener(listener);
        }

        public void LinkImageListener(Action<Action<Image, byte?>> listener)
        {
            listener.Invoke(_editReceiptView.OnImageReceived);
        }

        public void LinkOnConnectionMadeToEditView(Action<EventHandler<ServerSocket.ConnectionChangedEventArgs>> listener)
        {
            listener.Invoke(_editReceiptView.OnAppConnectionChange);
        }

        public void LinkOpenPhoneCameraEditViewEvent(Action listener)
        {
            _editReceiptView.RegisterOpenPhoneCameraViewListener(listener);
        }
        private void CreateColumns()
        {
            ReceiptListView.View = View.Details;
            ReceiptListView.Columns.Add("Has Image");
            ReceiptListView.Columns.Add("Name");
            ReceiptListView.Columns.Add("Expiration date");
            ReceiptListView.Columns.Add("Purchase date");
            ReceiptListView.Columns.Add("Cost");
            ReceiptListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            foreach (ColumnHeader column in ReceiptListView.Columns)
            {
                _columnWidths.Add(column.Width);
            }

        }

        public void UpdateListView()
        {
            ReceiptListView.Items.Clear();
            foreach (KeyValuePair<string, Info> item in _receiptItems)
            {
                ListViewItem ltItem = new ListViewItem();
                if (item.Value.ImgPath != string.Empty)
                {
                    ltItem.ImageIndex = 0;
                }
                ltItem.SubItems.Add(item.Value.Name);
                ltItem.SubItems.Add(item.Value.ExpirationDate);
                ltItem.SubItems.Add(item.Value.PurchaseDate);
                ltItem.SubItems.Add(item.Value.Cost);
                ltItem.Tag = item.Value.ID;
                ReceiptListView.Items.Add(ltItem);
            }
            ImageList list = new ImageList();
            list.Images.Add(new Icon(SystemIcons.Information, 40, 40));
            ReceiptListView.SmallImageList = list;
            ReceiptListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            for (int i = 0; i < ReceiptListView.Columns.Count; i++)
            {
                if (ReceiptListView.Columns[i].Width < _columnWidths[i])
                {
                    ReceiptListView.Columns[i].Width = _columnWidths[i];
                }
            }

        }

        public void UpdateListView(Info item)
        {


            ListViewItem ltItem = new ListViewItem();
            ltItem.Checked = item.ImgPath != string.Empty;
            ltItem.SubItems.Add(item.Name);
            ltItem.SubItems.Add(item.ExpirationDate);
            ltItem.SubItems.Add(item.PurchaseDate);
            ltItem.SubItems.Add(item.Cost);
            ltItem.Tag = item.ID;
            ReceiptListView.Items.Add(ltItem);
            ReceiptListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            for (int i = 0; i < ReceiptListView.Columns.Count; i++)
            {
                if (ReceiptListView.Columns[i].Width < _columnWidths[i])
                {
                    ReceiptListView.Columns[i].Width = _columnWidths[i];
                }
            }

            _receiptItems.Add(item.ID, item);
        }

        public void EditListView(Info item)
        {
            if (_receiptItems.ContainsKey(item.ID))
            {
                _receiptItems[item.ID] = item;
                UpdateListView();
            }
            else
            {
                _receiptItems.Add(item.ID, item);
                UpdateListView(item);
            }
            
        }



        private void ColumnClick(object sender, ColumnClickEventArgs e)
        {

            // cases determine which column was pressed
            switch (e.Column)
            {

                // if column is name
                case 1:

                    SortColumn(Column.Name);
                    _sortOrder[(int)Column.Name] = !_sortOrder[(int)Column.Name];
                    break;

                // exp_date
                case 2:

                    SortColumn(Column.ExpDate);
                    _sortOrder[(int)Column.ExpDate] = !_sortOrder[(int)Column.ExpDate];
                    break;

                // purchase_date
                case 3:

                    SortColumn(Column.PurchDate);
                    _sortOrder[(int)Column.PurchDate] = !_sortOrder[(int)Column.PurchDate];
                    break;

                // price
                case 4:

                    SortColumn(Column.Cost);
                    _sortOrder[(int)Column.Cost] = !_sortOrder[(int)Column.Cost];
                    break;
            }
        }

        private void SortColumn(Column column)
        {
            List<ListViewItem> itemList = new List<ListViewItem>();  // create copy of existing items 
            for (int i = 0; i < ReceiptListView.Items.Count; i++)
            {
                itemList.Add(new ListViewItem());
                for (int ii = 0; ii < ReceiptListView.Items[i].SubItems.Count; ii++)
                {
                    if (ii == 0)
                    {
                        if (ReceiptListView.Items[i].ImageIndex == 0)
                        {
                            itemList[i].ImageIndex = 0;
                        }
                        //itemList[i].SubItems[0] = ReceiptListView.Items[i].SubItems[ii];
                    }
                    else
                    {
                        itemList[i].SubItems.Add(ReceiptListView.Items[i].SubItems[ii]);
                    }

                }
                itemList[i].Tag = ReceiptListView.Items[i].Tag;

            }

            ReplaceInRightOrder(GetOrderedStrings(itemList, column), itemList, column);

        }





        private void ReplaceInRightOrder(List<string> orderedList, List<ListViewItem> itemList, Column column)
        {

            int amount = orderedList.Count();
            int placed = 0;



            while (true)
            {
                if (placed == amount)
                {
                    break;
                }
                for (int i = 0; i < itemList.Count(); i++)
                {
                    var temp = orderedList[placed];
                    var temp1 = itemList[i].SubItems[(int)column].Text;
                    if (itemList[i].SubItems[(int)column].Text == orderedList[placed])
                    {

                        ReceiptListView.Items[placed] = itemList[i];
                        placed++;
                        itemList.RemoveAt(i);


                    }
                }
            }
            return;
        }

        private List<string> GetOrderedStrings(List<ListViewItem> itemList, Column columnIndex)
        {
            List<string> strings = new List<string>();
            switch (columnIndex)
            {
                case Column.Name:

                    foreach (ListViewItem item in itemList)
                    {
                        strings.Add(item.SubItems[(int)columnIndex].Text);
                    }
                    if (_sortOrder[(int)columnIndex])
                    {
                        strings.Reverse();
                    }
                    else
                    {
                        strings.Sort();
                    }


                    return strings;

                case Column.ExpDate:
                    List<DateTime> expDates = new List<DateTime>();
                    foreach (ListViewItem item in itemList)
                    {
                        expDates.Add(DateTime.Parse(item.SubItems[(int)columnIndex].Text));
                    }
                    if (_sortOrder[(int)columnIndex])
                    {
                        expDates.Reverse();
                    }
                    else
                    {
                        expDates.Sort();
                    }
                    foreach (DateTime date in expDates)
                    {
                        strings.Add(date.ToString("dd/MM/yyyy"));
                    }

                    return strings;

                case Column.PurchDate:
                    List<DateTime> purchDates = new List<DateTime>();
                    foreach (ListViewItem item in itemList)
                    {
                        purchDates.Add(DateTime.Parse(item.SubItems[(int)columnIndex].Text));
                    }
                    if (_sortOrder[(int)columnIndex])
                    {
                        purchDates.Reverse();
                    }
                    else
                    {
                        purchDates.Sort();
                    }
                    foreach (DateTime date in purchDates)
                    {
                        strings.Add(date.ToString("dd/MM/yyyy"));
                    }
                    return strings;

                case Column.Cost:
                    CultureInfo _cultureInfo = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    _cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
                    List<double> costs = new List<double>();
                    foreach (ListViewItem item in itemList)
                    {
                        costs.Add(double.Parse(item.SubItems[(int)columnIndex].Text, _cultureInfo));
                    }
                    if (_sortOrder[(int)columnIndex])
                    {
                        costs.Reverse();
                    }
                    else
                    {
                        costs.Sort();
                    }
                    for (int i = 0; i < costs.Count; i++)
                    {
                        Debug.WriteLine(costs[i]);
                        strings.Add(costs[i].ToString(_cultureInfo));
                        strings[i] = strings[i];
                        Debug.WriteLine(strings[i]);
                    }
                    return strings;
            }
            return strings;
        }


        private void ReceiptListView_ItemActivate(object sender, EventArgs e)
        {
            if (ReceiptListView.SelectedItems.Count == 1)
            {
                _receiptItems.TryGetValue(ReceiptListView.SelectedItems[0].Tag.ToString(), out Info item);
                if (item != null)
                {
                    if (item.ImgPath != string.Empty)
                    {
                        ShowPic(item);
                        return;
                    }
                }
                


            }
        }

        private void ShowPic(Info info)
        {
            _imageViewer.AddImage(Image.FromFile(info.ImgPath), null);
            _imageViewer.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_selectedItem is null)
            {
                return;
            }
            _receiptItems.Remove(_selectedItem.Tag.ToString());
            UpdateListView();
            DeleteButton.Enabled = false;


        }

        private void ReceiptListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (ReceiptListView.SelectedItems.Count == 0)
            {
                DeleteButton.Enabled = false;
                EditButton.Enabled = false;
                return;
            }

            _selectedItem = ReceiptListView.SelectedItems[0];
            DeleteButton.Enabled = true;
            EditButton.Enabled = true;
        }

        private void SetControls()
        {
            DeleteButton.Enabled = false;
        }

        public void Write()
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Info>));
            using (StreamWriter stream = new StreamWriter(Path.Combine(Settings.Instance.ReceiptPath, Settings.Instance.ReceiptFile)))
            {
                List<Info> _temp = new List<Info>();
                foreach (KeyValuePair<string, Info> pair in _receiptItems)
                {
                    _temp.Add(pair.Value);
                }

                writer.Serialize(stream, _temp);
            }
        }

        public void Read()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Info>));
            if (!Directory.Exists(Settings.Instance.ReceiptPath))
            {
                Directory.CreateDirectory(Settings.Instance.ReceiptPath);
            }
            if (File.Exists(Path.Combine(Settings.Instance.ReceiptPath, Settings.Instance.ReceiptFile)))
            {
                if (new FileInfo(Path.Combine(Settings.Instance.ReceiptPath, Settings.Instance.ReceiptFile)).Length != 0)
                {
                    using (Stream reader = new FileStream(Path.Combine(Settings.Instance.ReceiptPath, Settings.Instance.ReceiptFile), FileMode.Open))
                    {
                        _receiptItems.Clear();
                        List<Info> _values = (List<Info>)serializer.Deserialize(reader);
                        foreach (Info receipt in _values)
                        {
                            _receiptItems.Add(receipt.ID, receipt);
                        }

                    }
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (_receiptItems.ContainsKey(_selectedItem.Tag as string))
            {
                _editReceiptView.FillWithInfoObject(_receiptItems[_selectedItem.Tag as string]);
                _editReceiptView.Show();
                _editReceiptView.BringToFront();
            }
        }
    }
}
