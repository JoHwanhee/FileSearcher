using System;
using System.IO;
using System.Linq;
using FileSearchr.Composite;
using Directory = FileSearchr.Composite.Directory;
using File = FileSearchr.Composite.File;

namespace FileSearchr
{
    public class FileSearcher
    {
        public void Search(Component parentComponent, string currentFolderName)
        {
            FileSearchConfig config = FileSearchConfig.Instance;

            try
            {
                DirectoryInfo currentDirectoryInfo = new DirectoryInfo(currentFolderName);
                Directory currentDirectory = new Directory(currentDirectoryInfo);

                foreach (var file in currentDirectoryInfo.GetFiles())
                {
                    bool isMatched = false;
                    foreach (string ignoreFile in config.IgnoreFiles)
                    {
                        if (file.Name.EndsWith(ignoreFile))
                        {
                            isMatched = true;
                            break;
                        }
                    }
                    if (!isMatched && file.LastWriteTime >= config.CompareTime)
                    {
                        currentDirectory.AddChlid(new File(file));
                    }
                }


                foreach (var direcotory in System.IO.Directory.GetDirectories(currentFolderName))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(direcotory);

                    if (config.IgnoreFolders.Contains(directoryInfo.Name))
                    {
                        continue;
                    }

                    Search(currentDirectory, directoryInfo.FullName);
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

        public void Delete(string currentFolderName)
        {
            Console.WriteLine($"Search {currentFolderName}");

            FileSearchConfig config = FileSearchConfig.Instance;
            DirectoryInfo currentDirectoryInfo = new DirectoryInfo(currentFolderName);

            foreach (var directory in System.IO.Directory.GetDirectories(currentDirectoryInfo.FullName))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                Delete(directoryInfo.FullName);
            }

            if (config.DeleteFolders.Contains(currentDirectoryInfo.Name))
            {
                //DeleteAll(currentDirectoryInfo.FullName);
                currentDirectoryInfo.Delete(true);
            }
        }

       /* private void DeleteAll(string currentFolderName)
        {
            foreach (var directory in System.IO.Directory.GetDirectories(currentFolderName))
            {
                try
                {
                    var currentInfo = new DirectoryInfo(directory);
                    currentInfo.Delete(true);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Cannot delete that {e}");
                }
            }

        }*/
    }
}
