using System.Text.Json.Serialization;
using pr0sharp.Converters;
using pr0sharp.DataTypes;
using pr0sharp.Enums;

namespace pr0sharp.Responses
{
    public class UserMeResponse
    {
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Registered")]
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime RegistrationDate { get; set; }
        public string Identifier { get; set; } = string.Empty;

        [JsonPropertyName("Mark")]
        public Pr0grammRanks Rank { get; set; }

        [JsonPropertyName("Score")]
        public long Benis { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime SubscribedUntil { get; set; }
        public BanInfo BanInfo { get; set; } = null!;
    }
}
