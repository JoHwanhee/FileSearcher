using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSearchr;
using FileSearchr.Composite;

namespace FileSearcherWindow.Models
{
    public class Files
    {
        public Component Root;
        public string SearchDirectory;

        public Files()
        {
            FileSearchConfig config = FileSearchConfig.Instance;
            config.Writer = new ResultXmlWriter();
            config.SearchDir = @"C:\Users\ChoHwanhee\Desktop\java";
            config.CompareTime = DateTime.Parse("2015-10-10");
            FileSearchManager fileSearchManager = new FileSearchManager(config);
            fileSearchManager.Run();
            Root = fileSearchManager.RootDirectory;
        }

    }
}
