using System;
using System.IO;
using System.Text;
using System.Xml;
using FileSearchr.Composite;
using File = FileSearchr.Composite.File;

namespace FileSearchr
{
    public class ResultTextWriter : IComponentWriter
    {
        public void Write(Component root, string saveFile)
        {
            using (StreamWriter file =
                new StreamWriter(saveFile))
            {
                Write(root as Folder, root.FullName.Length+1, file);
            }

        }

        private void Write(Folder currentFolder, int rootPathLenth, StreamWriter streamWriter)
        {
            foreach (var child in currentFolder.Children)
            {
                if (child.IsIgnore)
                {
                    continue;
                }

                switch (child)
                {
                    case Folder directory:
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
