using CommonUtils;
using LibGit2Sharp;
using System.Diagnostics;

namespace GitIconOverlayHandlers
{
    public static class GitUtil
    {
        private const string _committedKeywords = "nothing to commit, working tree clean";

        private const string _notPushedKeywords = "(use \"git push\" to publish your local commits)";

        public static GitStatus GetStatus(string floder)
        {
            //影响原有git的图标获取 好像与争抢仓库的IO有关
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
        public static GitStatus GetStatus1(string floder)
        {
            var repository = new Repository(floder);
            var info = repository.RetrieveStatus(new StatusOptions());

            return GitStatus.Committed;
        }
    }
}
