using CommonUtils;
using SharpShell.Attributes;

namespace GitIconOverlayHandlers
{
    [RegistrationName("  9GitConflict")]
    public class GitIconOverlayHandler_9Conflict : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Conflict;
    }
}
