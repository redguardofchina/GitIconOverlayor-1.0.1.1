using CommonUtils;
using GitIconOverlayHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIconOverlayHandlers_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RegeditUtil.SetToConfig(GitIconOverlayHandler.RootFloderFiled, PathUtil.Base);

            var hander1 = new GitIconOverlayHandler_3Committed();
            var hander2 = new GitIconOverlayHandler_9Conflict();
            var hander3 = new GitIconOverlayHandler_6Modified();
            var hander4 = new GitIconOverlayHandler_1Pushed();

            var path1 = @"D:\Subversion";
            var path2 = @"D:\Subversion\GitIconOverlayor";

            hander1.GetIconOverlayState(path1);
            hander2.GetIconOverlayState(path1);
            hander3.GetIconOverlayState(path1);
            hander4.GetIconOverlayState(path1);

            hander1.GetIconOverlayState(path2);
            hander2.GetIconOverlayState(path2);
            hander3.GetIconOverlayState(path2);
            hander4.GetIconOverlayState(path2);

            ConsoleUtil.Pause();
        }
    }
}
