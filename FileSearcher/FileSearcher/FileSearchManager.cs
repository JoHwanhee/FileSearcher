using System;
using FileSearchr.Composite;

namespace FileSearchr
{
    public class FileSearchManager
    {
        public Directory RootDirectory { get; set; } = new Directory();
        private readonly FileSearcher _fileSearcher = new FileSearcher();
        private readonly string _searchDir;
        private readonly string _saveFile;
        private readonly IComponentWriter _componentWriter;

        public FileSearchManager()
        {
            FileSearchConfig config = FileSearchConfig.Instance;
            _searchDir = config.SearchDir;
            _saveFile = config.SaveFile;
            _componentWriter = config.Writer;
        }

        public void Write()
        {
            _componentWriter.Write(RootDirectory, _saveFile);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {

        }

        public void Delete()
        {
            _fileSearcher.Delete(_searchDir);
        }
        
        public void Search()
        {
            Directory rootDirectory = new Directory();
            _fileSearcher.Search(rootDirectory, _searchDir);
            if (rootDirectory.Children.Count == 1)
            {
                RootDirectory = rootDirectory.Children[0] as Directory;
            }
            else
            {
                RootDirectory = rootDirectory;
            }
        }

        public void Run()
        {
            Search();
            Write();
            Close();
        }
    }
}