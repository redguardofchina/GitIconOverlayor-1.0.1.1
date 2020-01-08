using CommonUtils;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public static GitStatus GetStatus(string floder)
        {
            //hack 这个写法会影原有git的图标获取

            //var result = CommandUtil.Run("git status", floder);

            var startInfo = new ProcessStartInfo("git");
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
        //public static GitStatus GetGitStatus1(string floder)
        //{
        //    var info = new LibGit2Sharp.RepositoryInformation(floder);
        //}
    }
}
