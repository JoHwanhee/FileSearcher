using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSearchr.Composite
{
    public class Folder : Component
    {
        public Folder(DirectoryInfo directoryInfo)
        {
            Type = "Folder";
            FullName = directoryInfo.FullName;
            Name = directoryInfo.Name;
            Updated = directoryInfo.LastWriteTime;
        }
        public Folder()
        {
            Type = "Root";
            FullName = "";
            Name = "";
            Updated = DateTime.Now;

        }
        
    }
}