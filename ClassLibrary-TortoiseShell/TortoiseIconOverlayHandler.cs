using CommonUtils;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System.Drawing;

namespace ClassLibrary_TortoiseShell
{
    public class TortoiseIconOverlayHandler : SharpIconOverlayHandler
    {
        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            LogUtil.Log("CanShowOverlay");
            return true;
        }

        protected override Icon GetOverlayIcon()
        {
            LogUtil.Log("GetOverlayIcon");
            return new Icon(@"D:\Users\jianglong\Pictures\XPStyle\NotPush.ico");
        }

        protected override int GetPriority()
        {
            LogUtil.Log("GetPriority");
            return 4;
        }
    }
}
