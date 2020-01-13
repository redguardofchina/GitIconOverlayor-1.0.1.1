using CommonUtils;
using SharpShell.Attributes;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  1GitPushed")]
    public class GitIconOverlayHandler_1Pushed : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Pushed;
    }
}
