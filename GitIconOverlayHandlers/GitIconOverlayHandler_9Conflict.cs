using CommonUtils;
using SharpShell.Attributes;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  9GitConflict")]
    public class GitIconOverlayHandler_9Conflict : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Conflict;
    }
}
