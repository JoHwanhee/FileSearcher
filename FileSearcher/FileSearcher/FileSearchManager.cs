using System;
using System.IO;
using System.Linq;
using FileSearchr.Composite;
using Directory = FileSearchr.Composite.Directory;
using File = FileSearchr.Composite.File;

namespace FileSearchr
{
    public class FileSearchManager : IDisposable
    {
        private readonly IComponentWriter _componentWriter;
        private readonly string _searchDir;
        private readonly string _saveFile;
        private readonly DateTime _compareTime;
        private Directory _rootDirectory;

        public string[] IgnoreFolders { get; set; } = { "bin", "obj", ".vs", "packages" };
        public string[] IgnoreFiles { get; set; } = {".dll", ".pdb", ".csproj", ".sln", "Designer.cs", ".resx", "app.config", "packages.config", "App.xaml.cs" };
        
        public FileSearchManager(FileSearchConfig config)
        {
            _componentWriter = config.Writer;
            _searchDir = config.SearchDir;
            _saveFile = config.SaveFile;
            _compareTime = config.CompareTime;
            _rootDirectory = new Directory();
        }

        public void Write()
        {
            _componentWriter.Write(_rootDirectory, _saveFile);
        }

        public void Serach()
        {
            Directory rootDirectory = new Directory();
            Search(rootDirectory, _searchDir, _compareTime);
            if (rootDirectory.Children.Count == 1)
            {
                _rootDirectory = rootDirectory.Children[0] as Directory;
            }
            else
            {
                _rootDirectory = rootDirectory;
            }
        }

        public void Search(Component parentComponent, string currentFolderName, DateTime compareTime)
        {
            try
            {
                DirectoryInfo currentDirectoryInfo = new DirectoryInfo(currentFolderName);
                Directory currentDirectory = new Directory(currentDirectoryInfo);

                
                foreach (var file in currentDirectoryInfo.GetFiles())
                {
                    bool isMatched = false;
                    foreach (string ignoreFile in IgnoreFiles)
                    {
                        if (file.Name.EndsWith(ignoreFile))
                        {
                            isMatched = true;
                            break;
                        }
                    }
                    if (!isMatched && file.LastWriteTime >= _compareTime)
                    {
                        currentDirectory.AddChlid(new File(file));
                    }
                }

                foreach (var direcotory in System.IO.Directory.GetDirectories(currentFolderName))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(direcotory);

                    if (IgnoreFolders.Contains(directoryInfo.Name))
                    {
                        continue;
                    }

                    Search(currentDirectory, directoryInfo.FullName, compareTime);
                }

                if (currentDirectory.Children.Count > 0)
                {
                    parentComponent.AddChlid(currentDirectory);
                }
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }


        }
        public void Close()
        {
            Dispose();
        }
        public void Dispose()
        {

        }

        public void Run()
        {
            Serach();
            Write();
            Close();
        }
    }
}
