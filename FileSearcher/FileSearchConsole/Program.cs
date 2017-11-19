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
                FileSearchManager manager = new FileSearchManager();
                manager.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.Read();
        }
    }
}
