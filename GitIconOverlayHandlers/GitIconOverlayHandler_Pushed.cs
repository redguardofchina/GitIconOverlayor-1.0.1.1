using CommonUtils;
using SharpShell.Attributes;
using System.Runtime.InteropServices;

namespace GitIconOverlayHandlers
{
    [ComVisible(true)]
    [RegistrationName("  GitPushed")]
    public class GitIconOverlayHandler_Pushed : GitIconOverlayHandler
    {
        public override GitStatus Status { get; set; } = GitStatus.Pushed;
    }
}
