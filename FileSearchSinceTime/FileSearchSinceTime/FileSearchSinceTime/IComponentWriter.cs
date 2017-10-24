namespace FileSearchSinceTime
{
    public interface IComponentWriter
    {
        Component Root { get; set; }
        void Write();
        void Save(string saveFile);
    }
}