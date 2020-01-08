using CommonUtils;
using SharpShell.Attributes;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TortoiseGitNotPushedIconOverlayHandler
{
    [ComVisible(true)]
    [RegistrationName("  Tortoise0NotPushed")]
    public class TortoiseGitNotPushedIconOverlayHandler : SharpIconOverlayHandler
    {
        private static bool _hasGit = !CommandUtil.Run("git").HasError;

        private const string _keywords = "(use \"git push\" to publish your local commits)";

        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            if (!_hasGit)
                return false;

            if (!FileSystem.IsFloder(path))
                return false;

            if (!FloderUtil.Exists(path.Combine(".git")))
                return false;

            var result = CommandUtil.Run("git status", path);
            if (result.HasError)
                return false;

            return result.Result.Contains(_keywords);
        }

        private static Icon _notPushedIcon = new Icon(ResourceUtil.ReadStream("NotPushed.ico"));

        protected override Icon GetOverlayIcon()
        {
            return _notPushedIcon;
        }

        /// <summary>
        /// 优先级 0-100 0最高
        /// </summary>
        protected override int GetPriority()
        {
            return 0;
        }
    }
}
