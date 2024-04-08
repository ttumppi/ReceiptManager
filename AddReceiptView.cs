using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        public AddReceiptView(int tabHeight)
        {
            InitializeComponent();

            Read();

            setUCSize(tabHeight);
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
    }
}
