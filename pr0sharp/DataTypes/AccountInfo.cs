using System.Text.Json.Serialization;
using pr0sharp.Converters;

namespace pr0sharp.DataTypes
{
    public class AccountInfo
    {
        public bool LikesArePublic { get; set; }
        public bool DeviceMail { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Invites { get; set; }
        public bool IsInvited { get; set; }
        public int Mark { get; set; }
        public int MarkDefault { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime PaidUntil { get; set; }
        public bool HasBetaAccess { get; set; }
    }
}
