using FileSearchr.Composite;

namespace FileSearchr
{
    public interface IComponentWriter
    {
        Component Root { get; set; }
        void Write();
        void Save(string saveFile);
    }
}