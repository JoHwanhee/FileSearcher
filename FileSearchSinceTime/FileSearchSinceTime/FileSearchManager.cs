using System;
using System.IO;

namespace FileSearchSinceTime
{
    public class FileSearchManager : IDisposable
    {
        private readonly IComponentWriter _componentWriter;
        private readonly string _searchDir;
        private readonly string _saveFile;
        private readonly DateTime _compareTime;
        private readonly Directory _rootDirectory;
        
        public FileSearchManager(FileSearchConfig config)
        {
            _componentWriter = config.Writer;
            _searchDir = config.SearchDir;
            _saveFile = config.SaveFile;
            _compareTime = config.CompareTime;
            _rootDirectory = new Directory
            {
                Name = "Root",
                Updated = DateTime.Now
            };
        }

        public void Write()
        {
            _componentWriter.Root = _rootDirectory;
            _componentWriter.Write();
        }

        public void Save()
        {
            _componentWriter.Save(_saveFile);
        }

        public void Serach()
        {
            Search(_rootDirectory, _searchDir, _compareTime);
        }

        public void Search(Directory directory, string sDir, DateTime compareTime)
        {
            try
            {
                var comDirectories = System.IO.Directory.GetDirectories(sDir);

                foreach (var direcotory in comDirectories)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(direcotory);
                    Directory directoryComponent = new Directory { Name = directoryInfo.Name };
                    
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        if (file.LastWriteTime >= _compareTime)
                        {
                            directoryComponent.AddComponent(new File
                            {
                                Name = file.Name,
                                Updated = file.LastWriteTime
                            });
                        }
                    }

                    directory.AddComponent(directoryComponent);
                    Search(directoryComponent, direcotory, compareTime);
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
    }
}
