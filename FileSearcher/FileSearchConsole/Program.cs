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
            FileSearchConfig config = FileSearchConfig.Instance;
            FileSearchManager fileSearchManager = new FileSearchManager(config);
            fileSearchManager.Run();
        }
    }
}
