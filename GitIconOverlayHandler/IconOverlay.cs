using CommonUtils;

namespace GitIconOverlayHandler
{
    public static class IconOverlay
    {
        private static bool _hasGit = !CommandUtil.Run("git").HasError;

        public static bool CanShow(string path, GitStatus status)
        {
            if (!_hasGit)
                return false;

            if (!FileSystem.IsFloder(path))
                return false;

            if (!FloderUtil.Exists(path.Combine(".git")))
                return false;

            return status == GitUtil.GetStatus(path);
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
