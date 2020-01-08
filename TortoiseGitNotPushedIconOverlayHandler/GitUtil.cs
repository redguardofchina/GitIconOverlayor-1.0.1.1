using CommonUtils;
using System;
using System.Collections.Generic;
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
            var result = CommandUtil.Run("git status", floder);

            if (result.HasError)
                return GitStatus.Error;

            if (!result.Result.Contains(_committedKeywords))
                return GitStatus.Modified;

            if (result.Result.Contains(_notPushedKeywords))
                return GitStatus.Committed;

            return GitStatus.Pushed;
        }
    }
}
