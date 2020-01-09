using CommonUtils;
using LibGit2Sharp;
using System;
using System.Diagnostics;

namespace TortoiseGitNotPushedIconOverlayHandler
{
    public static class GitUtil
    {
        public enum GitStatus
        {
            Unknown,
            Error,
            Modified,
            Committed,
            Pushed
        }

        private const string _committedKeywords = "nothing to commit, working tree clean";

        private const string _notPushedKeywords = "(use \"git push\" to publish your local commits)";

        //public const string KeyOfGitPathInRegeditConfig = "GitPathForPlugin";

        //private static string _gitPath = RegeditUtil.GetConfig(KeyOfGitPathInRegeditConfig);

        public static GitStatus GetStatus(string floder)
        {
            //下面两种写法会影原有git的图标获取
            //var result = CommandUtil.Run("git status", floder);
            var startInfo = new ProcessStartInfo("git");

            //额外复制一份
            //var startInfo = new ProcessStartInfo(@"D:\Subversion\TortoiseGitNotPushedIconOverlayor\Git\cmd\git.exe");
            //var startInfo = new ProcessStartInfo(_gitPath);

            startInfo.Arguments = "status";
            startInfo.WorkingDirectory = floder;

            var result = ProcessUtil.Start(startInfo);

            if (result.HasError)
                return GitStatus.Error;

            if (!result.Result.Contains(_committedKeywords))
                return GitStatus.Modified;

            if (result.Result.Contains(_notPushedKeywords))
                return GitStatus.Committed;

            return GitStatus.Pushed;
        }

        //todo dowith LibGit2Sharp
        public static GitStatus GetStatus1(string floder)
        {
            var repository = new Repository(floder);
            var info = repository.RetrieveStatus(new StatusOptions());
            
            return GitStatus.Committed;
        }
    }
}
