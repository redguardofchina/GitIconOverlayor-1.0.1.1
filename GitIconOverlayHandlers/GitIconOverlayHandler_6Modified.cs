using CommonUtils;
using SharpShell.Attributes;

namespace GitIconOverlayHandlers
{
    [RegistrationName("  6GitModified")]
    public class GitIconOverlayHandler_6Modified : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Modified;
    }
}
