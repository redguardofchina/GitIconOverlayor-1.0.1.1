using CommonUtils;
using SharpShell.Attributes;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  GitConflict")]
    public class GitIconOverlayHandler_Conflict : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Conflict;
    }
}
