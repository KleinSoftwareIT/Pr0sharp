using System.Text.Json.Serialization;
using pr0sharp.Converters;

namespace pr0sharp.DataTypes
{
    public class BanInfo
    {
        [JsonPropertyName("Banned")]
        [JsonConverter(typeof(BoolConverter))]
        public bool IsBanned { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime? BannedUntil { get; set; }
    }
}
