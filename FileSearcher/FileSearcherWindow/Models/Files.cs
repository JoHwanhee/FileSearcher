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
            config.SearchDir = @"D:\Projects\4. 부산스마트시티\문서";
            config.CompareTime = DateTime.Parse("2015-10-10");
            
            FileSearchManager filemanager = new FileSearchManager();
            filemanager.Run();
            Root = filemanager.RootDirectory;
        }

    }
}
