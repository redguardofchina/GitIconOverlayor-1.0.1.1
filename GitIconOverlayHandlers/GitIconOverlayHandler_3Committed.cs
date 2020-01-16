using CommonUtils;
using SharpShell.Attributes;

namespace GitIconOverlayHandlers
{
    [RegistrationName("  3GitCommitted")]
    public class GitIconOverlayHandler_3Committed : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Committed;
    }
}
