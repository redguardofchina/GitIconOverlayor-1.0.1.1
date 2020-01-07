﻿using CommonUtils;
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
        protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
        {
            LogUtil.Log(path);

            if (FileSystem.IsFile(path))
                return false;

            if (FloderUtil.Exists(path.Combine(".git")))
                return true;

            return false;
        }

        private static Icon _notPushIcon = new Icon(ResourceUtil.ReadStream("NotPushed.ico"));

        protected override Icon GetOverlayIcon()
        {
            return _notPushIcon;
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
