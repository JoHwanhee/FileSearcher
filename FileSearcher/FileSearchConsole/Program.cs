using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSearchr;

namespace FileSearchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileSearchConfig config = FileSearchConfig.Instance;
                FileManager manager = new FileManager(config.SearchDir);
                manager.IgnoreFolders(config.IgnoreFolders);
                manager.IgnoreFiles(config.IgnoreFiles);
                manager.IgnoreByTime(config.CompareTime);
                manager.DeletesFolders(config.DeleteFolders);
                manager.Write(config.SaveFile, config.Writer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}
