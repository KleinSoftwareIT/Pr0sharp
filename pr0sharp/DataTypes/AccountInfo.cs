using System.Text.Json.Serialization;
using pr0sharp.Converters;
using pr0sharp.Enums;

namespace pr0sharp.DataTypes
{
    public class AccountInfo
    {
        public bool LikesArePublic { get; set; }
        public bool DeviceMail { get; set; }
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Invites")]
        public int AvailableInvites { get; set; }
        public bool IsInvited { get; set; }

        [JsonPropertyName("Mark")]
        public Pr0grammRanks Rank { get; set; }

        [JsonPropertyName("MarkDefault")]
        public Pr0grammRanks DefaultRank { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime PaidUntil { get; set; }
        public bool HasBetaAccess { get; set; }
    }
}
