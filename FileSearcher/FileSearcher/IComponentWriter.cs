using FileSearchr.Composite;

namespace FileSearchr
{
    public interface IComponentWriter
    {
        void Write(Component root, string saveFile);
    }
}