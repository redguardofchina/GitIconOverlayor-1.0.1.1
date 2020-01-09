using CommonUtils;
using System.Drawing;

namespace GitIconOverlayHandlers
{
    public static class Resources
    {
        public static readonly Icon ModifiedIcon = new Icon(ResourceUtil.ReadStream("resources.ModifiedIcon.ico"));
        public static readonly Icon CommittedIcon = new Icon(ResourceUtil.ReadStream("resources.CommittedIcon.ico"));
        public static readonly Icon PushedIcon = new Icon(ResourceUtil.ReadStream("resources.PushedIcon.ico"));
    }
}
