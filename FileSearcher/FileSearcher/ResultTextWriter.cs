using System;
using System.IO;
using System.Text;
using System.Xml;
using FileSearchr.Composite;
using Directory = FileSearchr.Composite.Directory;
using File = FileSearchr.Composite.File;

namespace FileSearchr
{
    public class ResultTextWriter : IComponentWriter
    {
        public void Write(Component root, string saveFile)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(saveFile))
            {
                Write(root as Directory, root.FullName.Length+1, file);
            }

        }

        private void Write(Directory currentDirectory, int rootPathLenth, StreamWriter streamWriter)
        {
            foreach (var child in currentDirectory.Children)
            {
                switch (child)
                {
                    case Directory directory:
                        Write(directory, rootPathLenth, streamWriter);
                        break;
                    case File file:
                        string path = Path.GetDirectoryName(file.FullName) ?? "";
                        if (path.Length > rootPathLenth)
                        {
                            path = path.Substring(rootPathLenth);
                        }
                        path = path.Replace("\\", "/");
                        streamWriter.WriteLine($"[{file.GetUpdatedDateString()}] [{path}] {file.Name}");
                        break;
                    default:
                        throw new ApplicationException();
                }
                
            }
        }
    }
}
