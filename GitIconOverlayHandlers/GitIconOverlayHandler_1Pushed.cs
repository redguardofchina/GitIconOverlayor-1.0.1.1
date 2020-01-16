using CommonUtils;
using SharpShell.Attributes;

namespace GitIconOverlayHandlers
{
    [RegistrationName("  1GitPushed")]
    public class GitIconOverlayHandler_1Pushed : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Pushed;
    }
}
