using CommonUtils;
using LibGit2Sharp;
using System.Diagnostics;

namespace GitIconOverlayHandler
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

        /*
        * 这个是TortoiseShell.IconOverlay.cpp源码，由此判断NotPushedIcon应该配置在6-100之间
        * https://github.com/TortoiseGit/TortoiseGit
       STDMETHODIMP CShellExt::GetPriority(int *pPriority)
       {
          if (!pPriority)
              return E_POINTER;

          switch (m_State)
          {
              case FileStateConflict:
                  *pPriority = 0;
                  break;
              case FileStateModified:
                  *pPriority = 1;
                  break;
              case FileStateDeleted:
                  *pPriority = 2;
                  break;
              case FileStateReadOnly:
                  *pPriority = 3;
                  break;
              case FileStateLockedOverlay:
                  *pPriority = 4;
                  break;
              case FileStateAddedOverlay:
                  *pPriority = 5;
                  break;
              case FileStateVersioned:
                  *pPriority = 6;
                  break;
              default:
                  *pPriority = 100;
                  return S_FALSE;
          }
          return S_OK;
       }
       */

        //上面的源码好像是假的 二分法测Tortoise的优先级都是100

        /// <summary>
        /// 优先级 0-100 0最高 100最低
        /// </summary>
        public const int Priority = 99;
    }
}
