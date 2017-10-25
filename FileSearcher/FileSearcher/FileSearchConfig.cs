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

        public string SearchDir = "D:\\work\\n3n\\src\\iw306\\application\\src";
        public string SaveFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
        public DateTime CompareTime = DateTime.Parse("2017-08-08");
        public IComponentWriter Writer = new ResultTextWriter();
    }
}