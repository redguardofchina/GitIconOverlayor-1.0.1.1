using SharpShell.Attributes;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  GitCommitted")]
    public class GitIconOverlayHandler_Committed : SharpIconOverlayHandler
    {
        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            //LogUtil.Log("CanShowOverlay");
            return IconOverlay.CanShow(path, GitStatus.Committed);
        }

        protected override Icon GetOverlayIcon()
        {
            //LogUtil.Log("GetOverlayIcon");
            return Resources.CommittedIcon;
        }

        protected override int GetPriority()
        {
            //LogUtil.Log("GetPriority");
            return IconOverlay.Priority;
        }
    }
}
