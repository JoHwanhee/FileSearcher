using System;
using System.IO;

namespace FileSearchr
{
    public class FileSearchConfig
    {
        private static readonly Lazy<FileSearchConfig> lazy =
            new Lazy<FileSearchConfig>(() => new FileSearchConfig());

        public static FileSearchConfig Instance => lazy.Value;

        private FileSearchConfig()
        {
        }

        public string SearchDir = "C:\\Users\\ChoHwanhee\\Documents\\기타 문서";
        public string SaveFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.xml");
        public DateTime CompareTime = DateTime.Parse("2014-01-24");
        public IComponentWriter Writer = new XmlComponentWriter(); 
    }
}