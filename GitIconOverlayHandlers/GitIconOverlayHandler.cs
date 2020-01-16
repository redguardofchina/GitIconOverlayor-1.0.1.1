using CommonUtils;
using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace GitIconOverlayHandlers
{
    public class GitIconOverlayHandler : SharpIconOverlayHandler
    {
        public virtual GitStatus Status { get; }

        //RegistrationName的ASCII码排序决定了访问优先级 可以按照这个理论定义RegistrationName和FirstAccessStatus，以达到效率优化
        public const GitStatus FirstAccessStatus = GitStatus.Pushed;

        public const string RootFloderFiled = "GitIconOverlayorFloder";

        private static readonly string _rootFloder = RegistryUtil.GetFromConfig(RootFloderFiled);

        static GitIconOverlayHandler()
        {
            PathConfig.SetRootFloder(_rootFloder);
            LogUtil.Log("Process {0} is startting handlers", ApplicationUtil.ProcessName);
        }

        protected GitIconOverlayHandler() : base()
        {
            LogUtil.Log("Process {0} is newing a handler of status {1}", ApplicationUtil.ProcessName, Status);
        }

        /// <summary>
        /// 优先级 0-100 0最高 100最低
        /// </summary>
        public const int Priority = 60;

        /// <summary>
        /// 获取图标覆盖优先级
        /// 优先级高的图标返回True优先级低的判断也不会停止，所以不需要分级
        /// </summary>
        protected override int GetPriority()
        {
            LogUtil.Log("Process {0} is getting the priority of status {1}", ApplicationUtil.ProcessName, Status);

            return Priority;
        }

        private static readonly string _iconsFloder = _rootFloder.Combine("icons");

        protected override Icon GetOverlayIcon()
        {
            LogUtil.Log("Process {0} is getting the icon of status {1}", ApplicationUtil.ProcessName, Status);

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

        private static readonly List<string> _notGitList = new List<string>();//HashSet<string>有个空指针异常，怀疑其线程不安全

        private static readonly Map<string, GitStatus> _statusMap = new Map<string, GitStatus>();

        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            try
            {
                if (ApplicationUtil.ProcessName != "explorer")
                    return false;

                //把优先级最高的结果缓存 低优先级直接读缓存

                //if (_notGitList.Contains(path))
                //    return false;

                //LogUtil.Log("{0}: Process is getting the show state of {1}", Status, path);

                if (Status == FirstAccessStatus)
                    _statusMap[path] = GitUtil.GetStatus(path);

                //_notGitList.Add(path);空文件夹检出项目时会混乱 虽然降效率了 没有太好的办法

                //LogUtil.Log("{0}: Process has got the show state of {1}", Status, path);

                return Status == _statusMap[path];
            }
            catch (Exception ex)
            {
                ex.HelpLink = Status + " " + path;
                LogUtil.Log(ex);
                return false;
            }
        }

        public bool GetIconOverlayState(string path)
        => CanShowOverlay(path, FILE_ATTRIBUTE.FILE_ATTRIBUTE_NORMAL);
    }
}
