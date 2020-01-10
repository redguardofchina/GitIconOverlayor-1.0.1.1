using CommonUtils;
using System.Drawing;

namespace GitIconOverlayHandlers
{
    public static class Resources
    {
        public static readonly Icon ModifiedIcon = new Icon(ResourceUtil.ReadStream("resources.ModifiedIcon.ico"));
        public static readonly Icon ConflictIcon = new Icon(ResourceUtil.ReadStream("resources.ConflictIcon.ico"));
        public static readonly Icon CommittedIcon = new Icon(ResourceUtil.ReadStream("resources.CommittedIcon.ico"));
        public static readonly Icon PushedIcon = new Icon(ResourceUtil.ReadStream("resources.PushedIcon.ico"));

        public static readonly Icon ModifiedIconWithUpdate = new Icon(ResourceUtil.ReadStream("resources.ModifiedIcon-u.ico"));
        public static readonly Icon ConflictIconWithUpdate = new Icon(ResourceUtil.ReadStream("resources.ConflictIcon-u.ico"));
        public static readonly Icon CommittedIconWithUpdate = new Icon(ResourceUtil.ReadStream("resources.CommittedIcon-u.ico"));
        public static readonly Icon PushedIconWithUpdate = new Icon(ResourceUtil.ReadStream("resources.PushedIcon-u.ico"));
    }
}
