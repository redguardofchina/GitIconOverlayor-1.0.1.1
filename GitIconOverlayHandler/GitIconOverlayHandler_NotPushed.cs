using CommonUtils;
using SharpShell.Attributes;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandler
{
    [ComVisible(true)]
    [RegistrationName("  GitNotPushed")]
    public class GitIconOverlayHandler_NotPushed : SharpIconOverlayHandler
    {
        private static bool _hasGit = !CommandUtil.Run("git").HasError;

        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            //LogUtil.Log("CanShowOverlay");

            if (!_hasGit)
                return false;

            if (!FileSystem.IsFloder(path))
                return false;

            if (!FloderUtil.Exists(path.Combine(".git")))
                return false;

            //ThreadUtil.Sleep(5);//让出IO

            var result = GitUtil.GetStatus(path) == GitStatus.Committed;

            if (!result)
                ThreadUtil.Sleep(1);//释放IO

            return result;
        }

        private static Icon _notPushedIcon = new Icon(ResourceUtil.ReadStream("resources.NotPushedIcon.ico"));

        protected override Icon GetOverlayIcon()
        {
            //LogUtil.Log("GetOverlayIcon");

            return _notPushedIcon;
        }

        protected override int GetPriority()
        {
            //LogUtil.Log("GetPriority");

            return GitUtil.Priority;
        }
    }
}
