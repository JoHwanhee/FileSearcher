using System.IO;

namespace FileSearchr.Composite
{
    public class File : Component
    {
        public File(FileInfo file)
        {
            Type = "File";
            FullName = file.FullName;
            Name = file.Name;
            Updated = file.LastWriteTime;

        }
        public override bool AddChlid(Component component)
        {
            return false;
        }
    }
}