using CommonUtils;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System.Drawing;

namespace GitIconOverlayHandlers
{
    public class GitIconOverlayHandler : SharpIconOverlayHandler
    {
        public virtual GitStatus Status { get; set; }

        /// <summary>
        /// 优先级 0-100 0最高 100最低
        /// </summary>
        public const int Priority = 99;

        protected override int GetPriority()
        {
            //LogUtil.Log("GetPriority");
            return Priority;
        }

        public const string FiledIconsFloder = "GitIconOverlayorIconsFloder";

        private static string _iconFloder = RegeditUtil.GetFromConfig(FiledIconsFloder);

        protected override Icon GetOverlayIcon()
        {
            //LogUtil.Log("GetOverlayIcon");
            switch (Status)
            {
                case GitStatus.Conflict:
                    return new Icon(_iconFloder.Combine("Conflict.ico"));
                case GitStatus.Modified:
                    return new Icon(_iconFloder.Combine("Modified.ico"));
                case GitStatus.Committed:
                    return new Icon(_iconFloder.Combine("Committed.ico"));
                case GitStatus.Pushed:
                    return new Icon(_iconFloder.Combine("Pushed.ico"));
                default:
                    return new Icon(_iconFloder.Combine("Unkonwn.ico"));
            }
        }

        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            //LogUtil.Log("CanShowOverlay");
            return Status == GitUtil.GetStatus(path);
        }
    }
}
