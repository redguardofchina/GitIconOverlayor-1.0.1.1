using CommonUtils;
using SharpShell.Attributes;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  3GitCommitted")]
    public class GitIconOverlayHandler_3Committed : GitIconOverlayHandler
    {
        public override GitStatus Status { get; } = GitStatus.Committed;
    }
}
