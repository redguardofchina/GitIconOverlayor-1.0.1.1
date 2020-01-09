using CommonUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitIconOverlayHandler;

namespace ConsoleApp_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                LogUtil.Print(GitUtil.GetStatus(@"D:\Subversion\CommonUtils-dot-net"));
            }
        }
    }
}
