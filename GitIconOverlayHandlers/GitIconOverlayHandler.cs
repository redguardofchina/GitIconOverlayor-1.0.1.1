﻿using CommonUtils;
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

        public const string RootFloderFiled = "GitIconOverlayorFloder";

        private static readonly string _rootFloder = RegeditUtil.GetFromConfig(RootFloderFiled);

        static GitIconOverlayHandler()
        {
            PathConfig.SetRootFloder(_rootFloder);
        }

        protected GitIconOverlayHandler() : base()
        {
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

        public const GitStatus PrioritizedStatus = GitStatus.Pushed;

        private static readonly string _iconsFloder = _rootFloder.Combine("icons");

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

        private static readonly HashSet<string> _notGitList = new HashSet<string>();

        private GitStatus _pathStatus;

        private static readonly Map<string, GitStatus> _statusMap = new Map<string, GitStatus>();

        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            try
            {
                //LogUtil.Log(Status + " CanShowOverlay: " + path);

                //把优先级最高的结果缓存 低优先级直接读缓存
                if (_notGitList.Contains(path))
                    return false;

                if (Status == PrioritizedStatus)
                {
                    _pathStatus = GitUtil.GetStatus(path);
                    if (_pathStatus == GitStatus.Unknown)
                        _notGitList.Add(path);
                    else
                        _statusMap[path] = _pathStatus;
                }
                else
                {
                    _pathStatus = _statusMap.Get(path);
                }
                return Status == _pathStatus;
            }
            catch (Exception ex)
            {
                LogUtil.Log(ex);
                return false;
            }
        }
    }
}
