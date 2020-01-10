using CommonUtils;
using SharpShell.Attributes;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  GitPushed")]
    public class GitIconOverlayHandler_Pushed : SharpIconOverlayHandler
    {
        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            //LogUtil.Log("CanShowOverlay");
            return IconOverlay.CanShow(path, GitStatus.Pushed);
        }

        protected override Icon GetOverlayIcon()
        {
            //LogUtil.Log("GetOverlayIcon");
            return Resources.PushedIcon;
        }

        protected override int GetPriority()
        {
            //LogUtil.Log("GetPriority");
            return IconOverlay.Priority;
        }
    }
}
