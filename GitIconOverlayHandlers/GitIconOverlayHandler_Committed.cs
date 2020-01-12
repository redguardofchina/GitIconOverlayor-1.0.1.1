using CommonUtils;
using SharpShell.Attributes;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  GitCommitted")]
    public class GitIconOverlayHandler_Committed : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Committed;
    }
}
