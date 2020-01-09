using CommonUtils;
using GitIconOverlayHandlers;

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
