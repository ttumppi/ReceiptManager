using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Kuittisovellus
{
    [Serializable]
    public class UniqueIDGenerator: IXmlSerializable
    {
        [XmlIgnore]
        private List<string> _alphabets = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q",
            "r", "s", "t", "u", "v", "x", "y", "z" };


        private List<Counter> _indexes = new List<Counter>();
        private int _amountOfLetters = 1;

        
        
        

        public UniqueIDGenerator()
        {
            
        }
        public string GenerateUniqueID()
        {
            if (_indexes.Count == 0)
            {
                _indexes.Add(new Counter(_alphabets.Count - 1));
            }
            string _id = string.Empty;
            for (int i = 0; i < _amountOfLetters; i++)
            {
                _id += _alphabets[_indexes[i].Count];
            }
            _indexes[_indexes.Count()-1].Advance();
            if (_indexes[0].Reset)
            {
                _indexes.Add(new Counter(_alphabets.Count() - 1, _indexes[_indexes.Count() - 1]));
                _amountOfLetters++;
                _indexes[0].Reset = false;
            }
            
            return _id;
        }
        public void Write()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UniqueIDGenerator));
            using (StreamWriter stream = new StreamWriter(Path.Combine(Settings.Instance.SettingsPath, Settings.Instance.UniqueIDGeneratorFile)))
            {
                serializer.Serialize(stream, this);
            }
        }
        public static UniqueIDGenerator Read()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UniqueIDGenerator));
            if (!Directory.Exists(Settings.Instance.SettingsPath))
            {
                Directory.CreateDirectory(Settings.Instance.SettingsPath);
            }
            if (File.Exists(Path.Combine(Settings.Instance.SettingsPath, Settings.Instance.UniqueIDGeneratorFile)))
            {
                if (new FileInfo(Path.Combine(Settings.Instance.SettingsPath, Settings.Instance.UniqueIDGeneratorFile)).Length != 0)
                {
                    using (Stream stream = new FileStream(Path.Combine(Settings.Instance.SettingsPath, Settings.Instance.UniqueIDGeneratorFile), FileMode.Open))
                    {
                        return (UniqueIDGenerator)serializer.Deserialize(stream);
                    }
                }
            }
            return new UniqueIDGenerator();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("LetterAmount", _amountOfLetters.ToString());
            writer.WriteStartElement("Counters");
            foreach(Counter counter in _indexes)
            {
                writer.WriteStartElement("Counter");
                writer.WriteElementString("Amount", counter.Count.ToString());
                writer.WriteElementString("Max", counter.Max.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            
            
        }

        public void ReadXml(XmlReader reader)
        {
            while (!reader.EOF)
            {
                if (reader.Name == "LetterAmount")
                {
                    _amountOfLetters = Int32.Parse(reader.ReadElementContentAsString());
                    
                }
                if (reader.Name == "Counters")
                {
                    reader.Read();
                    while (reader.Name != "Counters")
                    {
                        while (reader.Name != "Amount")
                        {
                            reader.Read();
                        }
                        Counter counter = new Counter();
                        counter.ReadXml(reader);
                        _indexes.Add(counter);
                        while (reader.Name != "Amount")
                        {
                            if (reader.Name == "Counters")
                            {
                                break;
                            }
                            reader.Read();
                        }
                    }
                    

                }
                reader.Read();
            }
        }


    }

    public class Counter: IXmlSerializable
    {
        private int _counter;
        private int _max;
        private Counter? _link;
        private bool _reset = false;

        
        public bool Reset
        {
            get { return _reset; }
            set
            {
                if (!value)
                {
                    _reset = value;
                }
            }
        }
        public int Count
        {
            get { return _counter; }
        }

        public int Max
        {
            get { return _max; }
        }
        public Counter(int max)
        {
            _counter = 0;
            _max = max;
        }
        public Counter(int max, Counter link)
        {
            _counter = 0;
            _max = max;
            _link = link;
        }

        public Counter()
        {

        }
       
        public void Advance()
        {
            

            _counter++;
            checkMax();
        }
        private void checkMax()
        {
            if (_counter > _max)
            {
                _counter = 0;
                _reset = true;
                
                if (_link != null)
                {
                    _link.Advance();
                }
            }
            
        }

        public void WriteXml(XmlWriter writer)
        {

        }

        public void ReadXml(XmlReader reader)
        {
            _counter = Int32.Parse(reader.ReadElementContentAsString());
            _max = Int32.Parse(reader.ReadElementContentAsString());
        }
        
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
