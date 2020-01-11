using CommonUtils;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System;
using System.Drawing;

namespace GitIconOverlayHandlers
{
    public class GitIconOverlayHandler : SharpIconOverlayHandler
    {
        public virtual GitStatus Status { get; set; }

        public const string RootFloderFiled = "GitIconOverlayorFloder";

        private static string _rootFloder = RegeditUtil.GetFromConfig(RootFloderFiled);

        static GitIconOverlayHandler()
        {
            PathConfig.SetRootFloder(_rootFloder);
            LogUtil.Log("Process: " + ApplicationUtil.ProcessName);
        }

        /// <summary>
        /// 优先级 0-100 0最高 100最低
        /// </summary>
        public const int Priority = 60;

        /// <summary>
        /// 获取状态优先级 0-100 越小优先级越高
        /// </summary>
        protected override int GetPriority()
        {
            //LogUtil.Log(Status + " GetPriority");

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
                    LogUtil.Log("Has Bug !!!");
                    return 100;
            }
        }

        private static string _iconsFloder = _rootFloder.Combine("icons");

        protected override Icon GetOverlayIcon()
        {
            //LogUtil.Log(Status + " GetOverlayIcon");

            switch (Status)
            {
                case GitStatus.Conflict:
                    return new Icon(_iconsFloder.Combine("Conflict.ico"));
                case GitStatus.Modified:
                    return new Icon(_iconsFloder.Combine("Modified.ico"));
                case GitStatus.Committed:
                    return new Icon(_iconsFloder.Combine("Committed.ico"));
                case GitStatus.Pushed:
                    return new Icon(_iconsFloder.Combine("Pushed.ico"));
                default://按照逻辑Status不会出现这种情况
                    LogUtil.Log("Has Bug !!!");
                    return new Icon(_iconsFloder.Combine("Unknown.ico"));
            }
        }

        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            //LogUtil.Log(Status + " CanShowOverlay: " + path);

            try
            {
                //todo 把优先级最高的结果缓存 低优先级直接读缓存
                return Status == GitUtil.GetStatus(path);
            }
            catch (Exception ex)
            {
                LogUtil.Log(ex);
                return false;
            }
        }
    }
}
