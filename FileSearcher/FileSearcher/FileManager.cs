using System;
using System.IO;
using FileSearchr.Composite;
using File = FileSearchr.Composite.File;

namespace FileSearchr
{
    public class FileManager
    {
        public Folder RootFolder { get; set; }

        public FileManager(string searchDir)
        {
            Folder rootFolder = new Folder();
            Load(rootFolder, searchDir);

            if (rootFolder.Children.Count == 1)
            {
                RootFolder = rootFolder.Children[0] as Folder;
            }
            else
            {
                RootFolder = rootFolder;
            }
        }

        public void Write(string saveDir, IComponentWriter writer = null)
        {
            if (writer == null)
            {
                writer = new ResultTextWriter();
            }

            writer?.Write(RootFolder, saveDir);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {

        }

        public void DeletesFolders(string[] deleteFolders)
        {
            RootFolder?.DeleteTo(deleteFolders);
        }

        public void IgnoreFolders(string[] ignoreFolders)
        {
            RootFolder?.IgnoreByNames(ignoreFolders);
        }

        public void IgnoreFiles(string[] ignoreFiles)
        {
            RootFolder?.IgnoreByNames(ignoreFiles);
        }

        public void IgnoreByTime(DateTime compareTime)
        {
            RootFolder?.IgnoreByTimes(compareTime);
        }

        private void Load(Component parentComponent, string currentFolderName)
        {
            try
            {
                DirectoryInfo currentDirectoryInfo = new DirectoryInfo(currentFolderName);
                Folder currentFolder = new Folder(currentDirectoryInfo);

                foreach (var direcotory in Directory.GetDirectories(currentFolderName))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(direcotory);
                    Load(currentFolder, directoryInfo.FullName);
                }

                foreach (var file in currentDirectoryInfo.GetFiles())
                {
                    currentFolder.AddChlid(new File(file));
                }

                parentComponent.AddChlid(currentFolder);
            }
            catch (Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}