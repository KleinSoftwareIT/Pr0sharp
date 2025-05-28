using pr0sharp.DataTypes;

namespace pr0sharp.Responses
{
    public class UserMeResponse
    {
        public string Name { get; set; } = string.Empty;
        public long Registered { get; set; }
        public string Identifier { get; set; } = string.Empty;
        public int Mark { get; set; }
        public long Score { get; set; }
        public long SubscribedUntil { get; set; }
        public BanInfo BanInfo { get; set; } = null!;
    }
}
