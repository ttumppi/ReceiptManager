using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManager
{
    public class Settings
    {

        public Size UCSize = new Size(1500, 602);
        public int TabHeight;
        public string ReceiptPath = Application.StartupPath + "Receipts";
        public string FolderPath = Application.StartupPath;
        public string SettingsPath = Application.StartupPath + "Settings";

        public string ReceiptFile = "Receipts.xml";
        public string UniqueIDGeneratorFile = "UniqueIDGenerator.xml";

        public readonly static string ImagesPath = Path.Combine(Application.StartupPath, "Images");


        private static Settings _settings;
        private static object _lock = new object();
        public static Settings Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_settings == null)
                    {
                        _settings = new Settings();
                    }
                    return _settings;
                }
                
            }
            
        }

        public Settings()
        {
            if (!Directory.Exists(ImagesPath))
            {
                Directory.CreateDirectory(ImagesPath);
            }
        }
    }
}
