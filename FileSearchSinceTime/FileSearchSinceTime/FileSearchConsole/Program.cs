using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSearchSinceTime;

namespace FileSearchConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSearchConfig config = FileSearchConfig.Instance;
            FileSearchManager fileSearchManager = new FileSearchManager(config);
            fileSearchManager.Serach();
            fileSearchManager.Write();
            fileSearchManager.Save();
            fileSearchManager.Close();
        }
    }
}
