using System;
using System.Collections.Generic;
using System.IO;

namespace FileSearchr.Composite
{
    public class Directory : Component
    {
        public Directory(DirectoryInfo directoryInfo)
        {
            Type = "Directory";
            FullName = directoryInfo.FullName;
            Name = directoryInfo.Name;
            Updated = directoryInfo.LastWriteTime;
        }
        public Directory()
        {
            Type = "Root";
            FullName = "";
            Name = "";
            Updated = DateTime.Now;

        }

    }
}