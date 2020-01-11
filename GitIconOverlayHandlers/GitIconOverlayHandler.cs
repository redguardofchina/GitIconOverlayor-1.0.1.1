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
        public const int Priority = 60;

        /// <summary>
        /// 获取状态优先级 0-100 越小优先级越高
        /// </summary>
        protected override int GetPriority()
        {
            //LogUtil.Log("GetPriority");

            //根据GetStatus方法推导
            //switch (Status)
            //{
            //    case GitStatus.Conflict:
            //        return Priority + 0;
            //    case GitStatus.Modified:
            //        return Priority + 3;
            //    case GitStatus.Committed:
            //        return Priority + 6;
            //    case GitStatus.Pushed:
            //        return Priority + 9;
            //    default://按照逻辑Status不会出现这种情况
            //        return 100;
            //}

            //根据状态频率推导
            switch (Status)
            {
                case GitStatus.Pushed:
                    return Priority + 0;
                case GitStatus.Committed:
                    return Priority + 3;
                case GitStatus.Modified:
                    return Priority + 6;
                case GitStatus.Conflict:
                    return Priority + 9;
                default://按照逻辑Status不会出现这种情况
                    return 100;
            }
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
                default://按照逻辑Status不会出现这种情况
                    return new Icon(_iconFloder.Combine("Unknown.ico"));
            }
        }

        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            //LogUtil.Log("CanShowOverlay");
            return Status == GitUtil.GetStatus(path);
        }
    }
}
