using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ReceiptManager
{
    [Serializable]

    public class Info : IXmlSerializable
    {

        private string _name;
        private string _expirationDate;
        private string _purchaseDate;
        private string _cost;
        private string _imgPath;
        private string _id;

        public string ID
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public string ExpirationDate
        {
            get { return _expirationDate; }
            private set { _expirationDate = value; }
        }

        public string PurchaseDate
        {
            get { return _purchaseDate; }
            private set { _purchaseDate = value; }
        }

        public string Cost
        {
            get { return _cost; }
            private set { _cost = value; }
        }

        public string ImgPath
        {
            get { return _imgPath; }
            private set { _imgPath = value; }
        }

        //product name, expiration date , purchase date and product cost
        public Info(string Name, string Expiration_date, string Purchase_date, string Cost, string Img_path, string id)
        {
            _name = Name;
            _expirationDate = Expiration_date;
            _purchaseDate = Purchase_date;
            _cost = Cost;
            _imgPath = Img_path;
            _id = id;
        }
        public Info()
        {

        }

        public void WriteXml (XmlWriter writer)
        {
            PropertyInfo[] fieldInfo = this.GetType().GetProperties();
            foreach (PropertyInfo info in fieldInfo)
            {
                writer.WriteElementString(info.Name, info.GetValue(this).ToString());
            }
        }
        public void ReadXml (XmlReader reader)
        {
            reader.MoveToContent();
            reader.ReadStartElement();
            PropertyInfo[] fieldInfo = this.GetType().GetProperties();
            foreach (PropertyInfo info in fieldInfo)
            {
                info.SetValue(this, reader.ReadElementString());
            }
            reader.ReadEndElement();
        }

        public XmlSchema GetSchema()
        {
            return (null);
        }
    }
}
