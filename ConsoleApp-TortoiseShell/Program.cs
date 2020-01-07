using ClassLibrary_TortoiseShell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_TortoiseShell
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello SharpShell!!!");

            var hander = new TortoiseIconOverlayHandler();

            Console.WriteLine("Press any key to close!");
            Console.ReadKey();
        }
    }
}
