using CommonUtils;
using SharpShell.Attributes;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  GitModified")]
    public class GitIconOverlayHandler_Modified : SharpIconOverlayHandler
    {
        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            //LogUtil.Log("CanShowOverlay");
            return GitUtil.GetStatus(path) == GitStatus.Modified;
        }

        protected override Icon GetOverlayIcon()
        {
            //LogUtil.Log("GetOverlayIcon");
            return Resources.ModifiedIcon;
        }

        protected override int GetPriority()
        {
            //LogUtil.Log("GetPriority");
            return IconOverlay.Priority;
        }
    }
}
