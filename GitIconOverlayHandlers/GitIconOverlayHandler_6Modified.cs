using CommonUtils;
using SharpShell.Attributes;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  6GitModified")]
    public class GitIconOverlayHandler_6Modified : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Modified;
    }
}
