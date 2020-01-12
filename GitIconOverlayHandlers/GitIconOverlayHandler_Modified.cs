using CommonUtils;
using SharpShell.Attributes;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  GitModified")]
    public class GitIconOverlayHandler_Modified : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Modified;
    }
}
